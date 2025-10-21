using UnityEngine;
using UnityEngine.InputSystem;

using System.Collections;

namespace Assets.App.BlockTest.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CameraZoom))]
    public class CameraControl : MonoBehaviour
    {
        private static readonly WaitForSeconds ONE_SEC = new(1);

        private InputSystem_Actions input;
        private InputAction moveAction;
        private Vector2 moveValue;

        private Rigidbody2D c_rigidbody2d;
        private CameraZoom c_cameraZoom;

        void Awake()
        {
            input = new();
            moveAction = input.Observer.Move;

            c_rigidbody2d = GetComponent<Rigidbody2D>();
            c_cameraZoom = GetComponent<CameraZoom>();
        }

        void OnEnable()
        {
            input.Enable();
            c_cameraZoom.OnToggleZoom.AddListener(HandleToggleZoom);
        }

        void OnDisable()
        {
            input.Disable();
            c_cameraZoom.OnToggleZoom.RemoveListener(HandleToggleZoom);
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
            moveValue = moveAction.ReadValue<Vector2>();
        }

        void FixedUpdate()
        {
            c_rigidbody2d.linearVelocity = moveValue;
        }

        private void HandleToggleZoom()
        {
            StartCoroutine(DisableTemporarily(ONE_SEC));
        }

        private IEnumerator DisableTemporarily(WaitForSeconds timeToWait)
        {
            moveAction.Disable();
            yield return timeToWait;
            moveAction.Enable();
        }
    }
}
