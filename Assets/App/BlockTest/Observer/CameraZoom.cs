using System.Collections;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

namespace Assets.App.BlockTest.Observer
{
    [RequireComponent(typeof(ObserverControls))]
    public class ObserverZoom : MonoBehaviour
    {
        public readonly UnityEvent<bool> OnToggleZoomStart = new();
        public readonly UnityEvent<bool> OnToggleZoomEnd = new();
        public bool Zoomed { get; private set; }

        private PixelPerfectCamera pixelPerfectCamera;
        private Animator animator;
        private static readonly WaitForSeconds ONE_SEC = new(1);

        private ObserverControls c_observerControls;

        public readonly UnityEvent PostZoomEvent = new();

        void Start()
        {
            pixelPerfectCamera = GetComponentInChildren<PixelPerfectCamera>();
            animator = GetComponentInChildren<Animator>();

            c_observerControls = GetComponent<ObserverControls>();
            c_observerControls.ZoomAction.performed += HandleToggleZoom;
        }

        void OnDestroy()
        {
            c_observerControls.ZoomAction.performed -= HandleToggleZoom;
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


            TemporarilyDisable(ONE_SEC);
        }

        public void TemporarilyDisable(WaitForSeconds timeToWait)
        {
            StartCoroutine(TmpDisableRoutine(timeToWait));
        }

        private IEnumerator TmpDisableRoutine(WaitForSeconds timeToWait)
        {
            c_observerControls.Input.Disable();
            yield return timeToWait;
            c_observerControls.Input.Enable();
            PostZoomEvent.Invoke();
        }
    }
}
