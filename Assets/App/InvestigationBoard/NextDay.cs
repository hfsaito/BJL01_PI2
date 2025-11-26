using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using Assets.App.Common.Transitions;

namespace Assets.App.InvestigationBoard
{
    public class NextDay : MonoBehaviour
    {

        private Button c_button;
        [SerializeField] private FadeTransition fadeTransition;

        void Start()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            c_button = GetComponent<Button>();
            c_button.onClick.AddListener(HandleClick);
        }

        void OnDisable()
        {
            c_button.onClick.RemoveListener(HandleClick);
        }

        private void HandleClick()
        {
            Globals.DayCount++;
            if (Globals.DayCount < 4)
            {
                fadeTransition.AsyncLoadScene("InvestigationNight");
            } else
            {
                fadeTransition.AsyncLoadScene("Failure");
            }
        }
    }
}
