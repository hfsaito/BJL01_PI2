using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

using UnityEngine.Events;

namespace Assets.App.BlockTest.Scripts
{
    [RequireComponent(typeof(CameraControls))]
    public class CameraZoom : MonoBehaviour
    {
        public readonly UnityEvent<bool> OnToggleZoomStart = new();
        public readonly UnityEvent<bool> OnToggleZoomEnd = new();
        public bool Zoomed { get; private set; }

        private PixelPerfectCamera pixelPerfectCamera;
        private Animator animator;
        private static readonly WaitForSeconds ONE_SEC = new(1);

        private CameraControls c_cameraControls;

        void Awake()
        {
            c_cameraControls = GetComponent<CameraControls>();
        }

        void OnEnable()
        {
            c_cameraControls.ZoomAction.performed += HandleToggleZoom;
        }

        void OnDisable()
        {
            c_cameraControls.ZoomAction.performed -= HandleToggleZoom;
        }


        void Start()
        {
            pixelPerfectCamera = GetComponentInChildren<PixelPerfectCamera>();
            animator = GetComponentInChildren<Animator>();
        }

        private void HandleToggleZoom(InputAction.CallbackContext context)
        {
            Zoomed = !Zoomed;

            animator.SetTrigger("Toggle Zoom");

            if (pixelPerfectCamera.assetsPPU == 64)
            {
                pixelPerfectCamera.assetsPPU = 128;
            }
            else
            {
                pixelPerfectCamera.assetsPPU = 64;
            }

            c_cameraControls.TemporarilyDisable(ONE_SEC);
        }
    }
}
