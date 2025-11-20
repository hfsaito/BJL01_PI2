using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.App.InvestigationBoard
{
    public class NextDay : MonoBehaviour
    {
        private Button c_button;
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
                string nextSceneName = $"InvestigationDay {Globals.DayCount}";
                SceneManager.LoadScene(nextSceneName);
            } else
            {
                SceneManager.LoadScene("End");
            }
        }
    }
}
