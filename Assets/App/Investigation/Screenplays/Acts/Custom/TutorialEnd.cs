using UnityEngine;

using Assets.App.Investigation.Characters;
using Assets.App.Investigation.Observer;
using UnityEngine.InputSystem;

namespace Assets.App.Investigation.Screenplays.Acts.Tutorial
{
    [System.Serializable]
    public class TutorialEnd : Base
    {
        [SerializeField] private ObserverTutorial observerTutorial;
        [SerializeField] private GameObject tutorialTextBox;
        private InputSystem_Actions input;
        private bool continued = false;

        override protected ActState Initialize(Character character)
        {
            input.Enable();
            input.Observer.Continue.performed += HandleContinue;

            tutorialTextBox.SetActive(true);
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
            input.Observer.Continue.performed -= HandleContinue;
        }

        private void HandleContinue(InputAction.CallbackContext _context)
        {
            tutorialTextBox.SetActive(false);
            continued = true;
            observerTutorial.TutorialEnd();
        }

    }
}
