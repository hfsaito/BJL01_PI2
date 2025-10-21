using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.App.BlockTest.Scripts
{
    [RequireComponent(typeof(CameraZoom))]
    [RequireComponent(typeof(CameraControls))]
    public class CameraPhoto : MonoBehaviour
    {
        private RaycastHit2D hit;

        private CameraControls c_cameraControls;
        private CameraZoom c_cameraZoom;

        void Awake()
        {
            c_cameraControls = GetComponent<CameraControls>();
            c_cameraZoom = GetComponent<CameraZoom>();
        }

        void OnEnable()
        {
            c_cameraControls.PhotoAction.performed += HandlePhoto;
        }

        void OnDisable()
        {
            c_cameraControls.PhotoAction.performed -= HandlePhoto;
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
