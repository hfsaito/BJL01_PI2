using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.App.BlockTest.Scripts
{
    [RequireComponent(typeof(CameraZoom))]
    public class CameraPhoto : MonoBehaviour
    {
        private InputSystem_Actions input;
        private InputAction photoAction;
        private RaycastHit2D hit;

        private CameraZoom c_cameraZoom;

        void Awake()
        {
            input = new();
            photoAction = input.Observer.Photo;
            c_cameraZoom = GetComponent<CameraZoom>();
        }

        void OnEnable()
        {
            input.Enable();
            photoAction.performed += HandlePhoto;
        }

        void OnDisable()
        {
            input.Disable();
            photoAction.performed -= HandlePhoto;
        }

        private void HandlePhoto(InputAction.CallbackContext _context)
        {
            if (!c_cameraZoom.Zoomed) return;
            hit = Physics2D.CircleCast((Vector2)transform.position, 2, Vector2.zero, 0f);
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
