using UnityEngine;
using UnityEngine.EventSystems;

using Assets.App.Common.Clues;
using Assets.App.Common.Data;

namespace Assets.App.InvestigationBoard.Inspectors.Clue
{
    public class ClueInspect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private ClueId clueId;

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.pointerEnter != gameObject) return;
            DisplayerConnector.Inspect(
                CluesData.TextByClue[clueId]
            );
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (eventData.pointerEnter != gameObject) return;
            DisplayerConnector.Inspect(
                CluesData.TextByClue[ClueId.NONE]
            );
        }

        void Start()
        {
            gameObject.SetActive(
                CluesData.IsClueUnlocked(clueId)
            );
        }
    }
}
