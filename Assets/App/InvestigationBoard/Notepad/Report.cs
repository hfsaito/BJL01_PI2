using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

namespace Assets.App.InvestigationBoard.Notepad
{
    [RequireComponent(typeof(Button))]
    public class Report : MonoBehaviour
    {
        private Button button;

        void Awake()
        {
            button = GetComponent<Button>();
            button.interactable = NotepadData.CanReport();
        }

        void OnEnable()
        {
            NotepadData.OnReportChange += HandleReportChange;
            button.onClick.AddListener(HandleReport);
        }

        void OnDisable()
        {
            NotepadData.OnReportChange -= HandleReportChange;
            button.onClick.RemoveListener(HandleReport);
        }

        private void HandleReportChange()
        {
            button.interactable = NotepadData.CanReport();
        }

        private void HandleReport()
        {
            SceneManager.LoadScene("Success");
        }
    }
}