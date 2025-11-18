using UnityEngine;
using UnityEngine.EventSystems;

using Assets.App.Common.Clues;

namespace Assets.App.InvestigationBoard.ClueInspector
{
    public class ClueInspect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private ClueId clueId;

        public void OnPointerEnter(PointerEventData _)
        {
            Globals.ClueInspected(clueId);
        }

        public void OnPointerExit(PointerEventData _)
        {
            Globals.ClueInspected(ClueId.NONE);
        }

        void Start()
        {
            gameObject.SetActive(
                Globals.Clues.ContainsKey(clueId) &&
                Globals.Clues[clueId]
            );
        }
    }
}
