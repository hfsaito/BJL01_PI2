using System;
using System.Collections;

using UnityEngine;
using UnityEngine.InputSystem;

using Assets.App.Investigation.Clues;

namespace Assets.App.Investigation.Observer
{
    [RequireComponent(typeof(ObserverZoom))]
    [RequireComponent(typeof(ObserverControls))]
    public class ObserverPhoto : MonoBehaviour
    {
        private ObserverControls c_observerControls;
        private ObserverZoom c_observerZoom;

        private int clueLayer;
        private RaycastHit2D[] hits;

        public event Action OnPhotoStart;
        private static readonly WaitForSeconds DEBOUNCE = new(1f);

        void OnEnable()
        {
            if (c_observerControls != null)
            {
                c_observerControls.PhotoAction.performed += HandlePhoto;
            }
        }

        void OnDisable()
        {
            if (c_observerControls != null)
            {
                c_observerControls.PhotoAction.performed -= HandlePhoto;
            }
        }

        void Start()
        {
            c_observerControls = GetComponent<ObserverControls>();
            c_observerZoom = GetComponent<ObserverZoom>();

            clueLayer = LayerMask.GetMask("Clue");

            c_observerControls.PhotoAction.performed += HandlePhoto;
        }

        private void HandlePhoto(InputAction.CallbackContext _context)
        {
            if (!c_observerZoom.Zoomed) return;

            CheckForClues();
            TemporarilyDisable(DEBOUNCE);
        }

        private void CheckForClues()
        {
            hits = Physics2D.CircleCastAll(
                (Vector2)transform.position,
                2,
                Vector2.zero,
                0f,
                clueLayer
            );

            foreach(RaycastHit2D hit in hits)
            {
                if (
                    hit.collider != null &&
                    hit.collider.gameObject.TryGetComponent<Clue>(out var clue)
                )
                {
                    clue.Capture();
                }
            }
        }

        private void TemporarilyDisable(WaitForSeconds timeToWait)
        {
            StartCoroutine(TmpDisableRoutine(timeToWait));
        }
        private IEnumerator TmpDisableRoutine(WaitForSeconds timeToWait)
        {
            c_observerControls.Input.Disable();
            OnPhotoStart.Invoke();
            yield return timeToWait;
            c_observerControls.Input.Enable();
        }

        #region EDITOR
        void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, 2);
        }
        #endregion
    }
}
