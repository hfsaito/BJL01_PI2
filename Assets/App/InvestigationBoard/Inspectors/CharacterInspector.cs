using UnityEngine;
using UnityEngine.EventSystems;

using Assets.App.Common.Data;

namespace Assets.App.InvestigationBoard.Inspectors.Character
{
    public class CharacterInspector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private CharacterId character;

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.pointerEnter != gameObject) return;
            BaloonConnector.InspectPointerEnter(
                CharactersData.ToBaloonResourcePath[character]
            );
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (eventData.pointerEnter != gameObject) return;
            BaloonConnector.InspectPointerExit();
        }

        void Start()
        {
            gameObject.SetActive(
                CharactersData
                    .IsCharacterUnlockedInBoard(character)
            );
        }
    }
}
