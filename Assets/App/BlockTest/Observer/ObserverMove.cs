using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.App.BlockTest.Observer
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(ObserverControls))]
    [RequireComponent(typeof(ObserverZoom))]
    public class ObserverMove : MonoBehaviour
    {
        private Camera c_camera;
        private Rigidbody2D c_rigidbody2d;

        private ObserverControls c_observerControls;
        private ObserverZoom c_observerZoom;

        private Vector2 moveValue;
        private Bounds cameraPositionBounds;

        void Start()
        {
            c_rigidbody2d = GetComponent<Rigidbody2D>();
            c_observerControls = GetComponent<ObserverControls>();

            c_camera = GetComponentInChildren<Camera>();
            c_observerControls.ZoomAction.performed += HandleToggleZoom;
            UpdateCameraBounds();

            c_observerZoom = GetComponent<ObserverZoom>();
            c_observerZoom.OnToggleZoomEnd += UpdateCameraBounds;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        void OnDestroy()
        {
            c_observerControls.ZoomAction.performed -= HandleToggleZoom;
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
            moveValue = c_observerControls.MoveAction.ReadValue<Vector2>();
        }

        void FixedUpdate()
        {
            FixedUpdate_MoveInsideWorldBounds();
        }

        private void FixedUpdate_MoveInsideWorldBounds()
        {
            var nextPosition = Time.fixedDeltaTime * moveValue + c_rigidbody2d.position;
            if (cameraPositionBounds.Contains(nextPosition))
            {
                c_rigidbody2d.linearVelocity = moveValue;
            }
            else
            {
                c_rigidbody2d.linearVelocity = Vector2.zero;
                c_rigidbody2d.position = cameraPositionBounds.ClosestPoint(nextPosition);
            }
        }

        private void HandleToggleZoom(InputAction.CallbackContext _)
        {
            UpdateCameraBounds();
        }

        private void UpdateCameraBounds()
        {
            cameraPositionBounds = new(
                Globals.WorldBounds.center,
                Globals.WorldBounds.size - GetCameraOrthograpicSize()
            );
        }

        private Vector3 GetCameraOrthograpicSize()
        {
            return new Vector3(
                2 * c_camera.orthographicSize * c_camera.aspect,
                2 * c_camera.orthographicSize
            );
        }
    }
}
