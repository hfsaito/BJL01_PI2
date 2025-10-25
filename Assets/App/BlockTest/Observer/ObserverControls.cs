using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.App.BlockTest.Observer
{
    public class ObserverControls : MonoBehaviour
    {
        public InputSystem_Actions Input { get; private set; }
        public InputAction MoveAction { get; private set; }
        public InputAction ZoomAction { get; private set; }
        public InputAction PhotoAction { get; private set; }

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
        }

        void OnDisable()
        {
            Input.Disable();
        }
    }
}
