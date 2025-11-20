using UnityEngine;
using UnityEngine.EventSystems;

using Assets.App.Common.Clues;

namespace Assets.App.InvestigationBoard.ClueInspector
{
    public class SuspectInspect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private BlameOptionSuspect suspectId;

        public void OnPointerEnter(PointerEventData _)
        {
        //     Globals.ClueInspected(suspectId);
        }

        public void OnPointerExit(PointerEventData _)
        {
        //     Globals.ClueInspected(ClueId.NONE);
        }

        // void Start()
        // {
        //     gameObject.SetActive(
        //         Globals.Clues.ContainsKey(suspectId) &&
        //         Globals.Clues[suspectId]
        //     );
        // }
    }
}
