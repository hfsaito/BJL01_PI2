using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

using System.Collections;
using UnityEngine.Events;

namespace Assets.App.BlockTest.Scripts
{
    public class CameraZoom : MonoBehaviour
    {
        private InputSystem_Actions input;
        private InputAction zoomAction;

        public UnityEvent OnToggleZoom { get; private set; }
        public bool Zoomed { get; private set; }

        private PixelPerfectCamera pixelPerfectCamera;
        private Animator animator;
        readonly WaitForSeconds delayBetweenZoomToggles = new(1f);

        void Awake()
        {
            input = new();
            zoomAction = input.Observer.Zoom;
        }

        void OnEnable()
        {
            zoomAction.performed += HandleToggleZoom;
        }

        void OnDisable()
        {
            zoomAction.performed -= HandleToggleZoom;
        }


        void Start()
        {
            pixelPerfectCamera = GetComponentInChildren<PixelPerfectCamera>();
            animator = GetComponentInChildren<Animator>();
        }

        private void HandleToggleZoom(InputAction.CallbackContext context)
        {
            animator.SetTrigger("Toggle Zoom");
            if (pixelPerfectCamera.assetsPPU == 64)
            {
                pixelPerfectCamera.assetsPPU = 128;
            } else
            {
                pixelPerfectCamera.assetsPPU = 64;
            }
            Zoomed = !Zoomed;
            OnToggleZoom.Invoke();
            StartCoroutine(DisableToggleTemporarily());
        }

        private IEnumerator DisableToggleTemporarily()
        {
            zoomAction.Disable();
            yield return delayBetweenZoomToggles;
            zoomAction.Enable();
        }
    }
}
