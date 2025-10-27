using System;
using System.Collections;

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

namespace Assets.App.BlockTest.Observer
{
    [RequireComponent(typeof(ObserverControls))]
    public class ObserverZoom : MonoBehaviour
    {
        public bool Zoomed { get; private set; }

        private PixelPerfectCamera c_pixelPerfectCamera;
        private ObserverControls c_observerControls;

        private static readonly WaitForSeconds DEBOUNCE = new(1f);
        private static readonly WaitForSeconds HALF_DEBOUNCE = new(.5f);

        public event Action OnZoomStart;
        public event Action OnZoomPPUUpdated;
        public event Action OnZoomEnd;

        void Start()
        {
            c_pixelPerfectCamera = GetComponentInChildren<PixelPerfectCamera>();

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
            UpdateCameraPPUInNextFrame();
            TemporarilyDisable(DEBOUNCE);
        }

        private void UpdateCameraPPUInNextFrame()
        {
            StartCoroutine(UpdateCameraPPUInNextFrameRoutine());
        }
        private IEnumerator UpdateCameraPPUInNextFrameRoutine()
        {
            yield return HALF_DEBOUNCE;
            c_pixelPerfectCamera.assetsPPU = c_pixelPerfectCamera.assetsPPU == 64 ? 128 : 64;
            yield return new WaitForEndOfFrame();
            OnZoomPPUUpdated?.Invoke();
        }

        private void TemporarilyDisable(WaitForSeconds timeToWait)
        {
            StartCoroutine(TmpDisableRoutine(timeToWait));
        }
        private IEnumerator TmpDisableRoutine(WaitForSeconds timeToWait)
        {
            c_observerControls.Input.Disable();
            OnZoomStart?.Invoke();
            yield return timeToWait;
            c_observerControls.Input.Enable();
            OnZoomEnd?.Invoke();
        }
    }
}
