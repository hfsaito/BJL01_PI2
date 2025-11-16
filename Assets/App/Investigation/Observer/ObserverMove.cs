using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.App.Investigation.Observer
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(ObserverControls))]
    [RequireComponent(typeof(ObserverZoom))]
    public class ObserverMove : MonoBehaviour
    {
        public float LerpFactor;
        public float MinLerpDelta;
        [SerializeField] private Camera mainCamera;

        private Rigidbody2D c_rigidbody2d;

        private ObserverControls c_observerControls;
        private ObserverZoom c_observerZoom;

        private Vector2 moveValue;
        private Bounds cameraPositionBounds;

        void Start()
        {
            c_rigidbody2d = GetComponent<Rigidbody2D>();
            c_observerControls = GetComponent<ObserverControls>();

            c_observerControls.ZoomAction.performed += HandleToggleZoom;
            UpdateCameraBounds();

            c_observerZoom = GetComponent<ObserverZoom>();
            c_observerZoom.OnZoomPPUUpdated += UpdateCameraBounds;

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

        private Vector3 mainCameraPositionAux;
        void LateUpdate()
        {
            mainCameraPositionAux = transform.position;
            mainCameraPositionAux.z = mainCamera.transform.position.z;
            mainCamera.transform.position = mainCameraPositionAux; // Vector3.MoveTowards(mainCamera.transform.position, mainCameraPositionAux, LerpFactor * Time.deltaTime);
        }

        void FixedUpdate()
        {
            FixedUpdate_MoveInsideWorldBounds();
        }

        private Vector2 nextPosition;
        private Vector2 auxMoveValue;
        private void FixedUpdate_MoveInsideWorldBounds()
        {
            auxMoveValue = c_rigidbody2d.linearVelocity - moveValue;
            if (auxMoveValue.magnitude > MinLerpDelta)
            {
                auxMoveValue = Vector2.Lerp(c_rigidbody2d.linearVelocity, moveValue, LerpFactor * Time.fixedDeltaTime);
            } else
            {
                auxMoveValue = moveValue;
            }

            nextPosition = Time.fixedDeltaTime * auxMoveValue + c_rigidbody2d.position;
            if (cameraPositionBounds.Contains(nextPosition))
            {
                c_rigidbody2d.linearVelocity = auxMoveValue;
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
                2 * mainCamera.orthographicSize * mainCamera.aspect,
                2 * mainCamera.orthographicSize
            );
        }
    }
}
