using TMPro;
using UnityEngine;

using Assets.App.Common.Clues;

namespace Assets.App.InvestigationBoard.Inspectors
{
    [RequireComponent(typeof(TMP_Text))]
    public class Displayer : MonoBehaviour
    {
        private TMP_Text c_text;

        void Awake()
        {
            c_text = GetComponent<TMP_Text>();
        }

        void OnEnable()
        {
            DisplayerConnector.OnInspect += DisplayText;
        }

        void OnDisable()
        {
            DisplayerConnector.OnInspect -= DisplayText;
        }

        private void DisplayText(string text)
        {
            c_text.text = text;
        }
    }
}
