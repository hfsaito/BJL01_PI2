using TMPro;
using UnityEngine;

using Assets.App.Common.Clues;

namespace Assets.App.InvestigationBoard.ClueInspector
{
    [RequireComponent(typeof(TMP_Text))]
    public class ClueDetailDisplayer : MonoBehaviour
    {
        private TMP_Text c_text;

        void Awake()
        {
            c_text = GetComponent<TMP_Text>();
        }

        void OnEnable()
        {
            Globals.OnClueInspected += DisplayClueInfo;
        }

        void OnDisable()
        {
            Globals.OnClueInspected -= DisplayClueInfo;
        }

        void DisplayClueInfo(ClueId clueId)
        {
            c_text.text = Clues.Detail[clueId];
        }
    }
}
