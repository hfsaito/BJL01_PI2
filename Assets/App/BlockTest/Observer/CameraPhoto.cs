using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.App.BlockTest.Observer
{
    [RequireComponent(typeof(ObserverZoom))]
    [RequireComponent(typeof(ObserverControls))]
    public class ObserverPhoto : MonoBehaviour
    {
        private RaycastHit2D hit;

        private ObserverControls c_ObserverControls;
        private ObserverZoom c_observerZoom;

        private int clueLayer;

        void OnEnable()
        {
            if (c_ObserverControls != null)
            {
                c_ObserverControls.PhotoAction.performed += HandlePhoto;
            }
        }

        void OnDisable()
        {
            if (c_ObserverControls != null)
            {
                c_ObserverControls.PhotoAction.performed -= HandlePhoto;
            }
        }

        void Start()
        {
            c_ObserverControls = GetComponent<ObserverControls>();
            c_observerZoom = GetComponent<ObserverZoom>();

            clueLayer = LayerMask.GetMask("Clue");

            c_ObserverControls.PhotoAction.performed += HandlePhoto;
        }

        private void HandlePhoto(InputAction.CallbackContext _context)
        {
            if (!c_observerZoom.Zoomed) return;
            hit = Physics2D.CircleCast(
                (Vector2)transform.position,
                2,
                Vector2.zero,
                0f,
                clueLayer
            );
            if (hit.collider != null)
            {
                Debug.Log("Achou pista!");
            }
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, 2);
        }
    }
}
