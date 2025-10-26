using System;
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
        public bool Zoomed { get; private set; }

        private PixelPerfectCamera c_pixelPerfectCamera;
        private Animator c_animator;
        private ObserverControls c_observerControls;

        private static readonly WaitForSeconds ONE_SEC = new(1);

        public event Action OnToggleZoomEnd;

        void Start()
        {
            c_pixelPerfectCamera = GetComponentInChildren<PixelPerfectCamera>();
            c_animator = GetComponentInChildren<Animator>();

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

            c_animator.SetTrigger("Zoom");

            if (c_pixelPerfectCamera.assetsPPU == 64)
            {
                c_pixelPerfectCamera.assetsPPU = 128;
            }
            else
            {
                c_pixelPerfectCamera.assetsPPU = 64;
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
            OnToggleZoomEnd.Invoke();
        }
    }
}
