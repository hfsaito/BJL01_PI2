using System;
using System.Collections;

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

namespace Assets.App.Investigation.Observer
{
    [RequireComponent(typeof(ObserverControls))]
    public class ObserverZoom : MonoBehaviour
    {
        public bool Zoomed { get; private set; }

        [SerializeField] private GameObject zoomHud;
        [SerializeField] private PixelPerfectCamera pixelPerfectCamera;

        private ObserverControls c_observerControls;

        private static readonly WaitForSeconds HALF_DEBOUNCE = new(.5f);

        public event Action OnZoomStart;
        public event Action OnZoomPPUUpdated;
        public event Action OnZoomEnd;

        void Start()
        {
            zoomHud.SetActive(false);

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
            Globals.ObserverZoomed = Zoomed;
            zoomHud.SetActive(Zoomed);
            StartCoroutine(HandleToggleZoomRoutine());
        }

        private IEnumerator HandleToggleZoomRoutine()
        {
            c_observerControls.Input.Disable();
            OnZoomStart?.Invoke();
            yield return HALF_DEBOUNCE;
            pixelPerfectCamera.assetsPPU = Zoomed ? 128 : 64;
            yield return new WaitForEndOfFrame();
            OnZoomPPUUpdated?.Invoke();
            yield return HALF_DEBOUNCE;
            c_observerControls.Input.Enable();
            OnZoomEnd?.Invoke();
        }
    }
}
