using UnityEngine;
using UnityEngine.InputSystem;

using Assets.App.BlockTest.Clues;

namespace Assets.App.BlockTest.Observer
{
    [RequireComponent(typeof(ObserverZoom))]
    [RequireComponent(typeof(ObserverControls))]
    public class ObserverPhoto : MonoBehaviour
    {
        private RaycastHit2D hit;

        private Animator c_animator;
        private ObserverControls c_observerControls;
        private ObserverZoom c_observerZoom;


        private int clueLayer;

        void OnEnable()
        {
            if (c_observerControls != null)
            {
                c_observerControls.PhotoAction.performed += HandlePhoto;
            }
        }

        void OnDisable()
        {
            if (c_observerControls != null)
            {
                c_observerControls.PhotoAction.performed -= HandlePhoto;
            }
        }

        void Start()
        {
            c_animator = GetComponentInChildren<Animator>();
            c_observerControls = GetComponent<ObserverControls>();
            c_observerZoom = GetComponent<ObserverZoom>();

            clueLayer = LayerMask.GetMask("Clue");

            c_observerControls.PhotoAction.performed += HandlePhoto;
        }

        private void HandlePhoto(InputAction.CallbackContext _context)
        {
            if (!c_observerZoom.Zoomed) return;

            c_animator.SetTrigger("Photo");

            hit = Physics2D.CircleCast(
                (Vector2)transform.position,
                2,
                Vector2.zero,
                0f,
                clueLayer
            );
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.TryGetComponent<Clue>(out var clue))
                {
                    clue.Capture();
                }
            }
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, 2);
        }
    }
}
