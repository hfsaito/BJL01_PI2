using UnityEngine;

namespace Assets.App.BlockTest.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CameraControls))]
    public class CameraMove : MonoBehaviour
    {
        private Vector2 moveValue;

        private Rigidbody2D c_rigidbody2d;
        private CameraControls c_cameraControls;

        void Awake()
        {
            c_rigidbody2d = GetComponent<Rigidbody2D>();
            c_cameraControls = GetComponent<CameraControls>();
        }

        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        void OnApplicationFocus(bool focus)
        {
            if (focus)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        void Update()
        {
            moveValue = c_cameraControls.MoveAction.ReadValue<Vector2>();
        }

        void FixedUpdate()
        {
            c_rigidbody2d.linearVelocity = moveValue;
        }
    }
}
