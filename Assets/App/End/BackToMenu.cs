using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

using Assets.App.Common.Transitions;


namespace Assets.App.End
{
    public class BackToMenu : MonoBehaviour
    {
        private InputSystem_Actions input;
        [SerializeField] private Button button;
        [SerializeField] private FadeTransition fadeTransition;

        void OnEnable()
        {
            button.onClick.AddListener(HandleContinue);
        }

        void OnDisable()
        {
            button.onClick.RemoveListener(HandleContinue);
        }

        private void HandleContinue()
        {
            fadeTransition.AsyncLoadScene("Start");
        }
    }
}
