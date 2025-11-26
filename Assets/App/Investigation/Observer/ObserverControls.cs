using UnityEngine;
using UnityEngine.InputSystem;

using Assets.App.Common.Transitions;

namespace Assets.App.Investigation.Observer
{
    public class ObserverControls : MonoBehaviour
    {
        public InputSystem_Actions Input { get; private set; }
        public InputAction MoveAction { get; private set; }
        public InputAction ZoomAction { get; private set; }
        public InputAction PhotoAction { get; private set; }

        [SerializeField] private FadeTransition fadeTransition;

        void Awake()
        {
            Input = new();
            MoveAction = Input.Observer.Move;
            ZoomAction = Input.Observer.Zoom;
            PhotoAction = Input.Observer.Photo;
        }

        void OnEnable()
        {
            Input.Enable();
            fadeTransition.OnSceneLoadStart += HandleSceneLoadStart;
        }

        void OnDisable()
        {
            Input.Disable();
            fadeTransition.OnSceneLoadStart -= HandleSceneLoadStart;
        }

        private void HandleSceneLoadStart()
        {
            Input.Disable();
        }
    }
}
