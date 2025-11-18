using UnityEngine;

using Assets.App.Investigation.Characters;
using Assets.App.Investigation.Observer;
using UnityEngine.InputSystem;
using System.Collections;

namespace Assets.App.Investigation.Screenplays.Acts.Tutorial
{
    [System.Serializable]
    public class TutorialStepPhoto : Base
    {
        [SerializeField] private ObserverTutorial observerTutorial;
        [SerializeField] private GameObject tutorialTextBox;
        private InputSystem_Actions input;
        private bool continued = false;

        override protected ActState Initialize(Character character)
        {
            tutorialTextBox.SetActive(true);
            observerTutorial.TutorialSetPhotoEnabled(true);

            input.Enable();
            input.Observer.Photo.performed += HandlePhoto;

            return ActState.RUNNING;
        }

        override protected ActState Run(Character character)
        {
            if (continued)
            {
                return ActState.DONE;
            }
            return ActState.RUNNING;
        }

        void Awake()
        {
            input = new();
        }

        void OnDisable()
        {
            input.Disable();
            input.Observer.Photo.performed -= HandlePhoto;
        }

        private void HandlePhoto(InputAction.CallbackContext _context)
        {
            StartCoroutine(HandleTogglePhotoRoutine());
            tutorialTextBox.SetActive(false);
            continued = true;
        }

        private IEnumerator HandleTogglePhotoRoutine()
        {
            yield return new WaitForEndOfFrame();
            observerTutorial.TutorialSetPhotoEnabled(false);
        }
    }
}
