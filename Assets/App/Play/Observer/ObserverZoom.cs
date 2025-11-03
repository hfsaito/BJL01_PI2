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

        [SerializeField] private GameObject zoomHud;

        private PixelPerfectCamera c_pixelPerfectCamera;
        private ObserverControls c_observerControls;

        private static readonly WaitForSeconds HALF_DEBOUNCE = new(.5f);

        public event Action OnZoomStart;
        public event Action OnZoomPPUUpdated;
        public event Action OnZoomEnd;

        void Start()
        {
            zoomHud.SetActive(false);
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
            zoomHud.SetActive(Zoomed);
            StartCoroutine(HandleToggleZoomRoutine());
        }

        private IEnumerator HandleToggleZoomRoutine()
        {
            c_observerControls.Input.Disable();
            OnZoomStart?.Invoke();
            yield return HALF_DEBOUNCE;
            c_pixelPerfectCamera.assetsPPU = c_pixelPerfectCamera.assetsPPU == 64 ? 128 : 64;
            yield return new WaitForEndOfFrame();
            OnZoomPPUUpdated?.Invoke();
            yield return HALF_DEBOUNCE;
            c_observerControls.Input.Enable();
            OnZoomEnd?.Invoke();
        }
    }
}
