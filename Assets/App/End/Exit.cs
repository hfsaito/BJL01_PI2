using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


namespace Assets.App.End
{
    public class Exit : MonoBehaviour
    {
        private Button button;
        private InputSystem_Actions input;

        void Awake()
        {
            button = GetComponent<Button>();
            input = new();
        }

        void OnEnable()
        {
            input.Enable();
            input.Observer.Continue.performed += HandleContinue;
        }

        void OnDisable()
        {
            input.Disable();
            input.Observer.Continue.performed -= HandleContinue;
        }

        private void HandleContinue(InputAction.CallbackContext _)
        {
            Application.Quit();
        }
    }
}
