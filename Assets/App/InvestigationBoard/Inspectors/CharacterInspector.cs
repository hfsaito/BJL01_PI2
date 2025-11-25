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
            DisplayerConnector.Inspect(
                CharactersData.TextByCharacter[character]
            );
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (eventData.pointerEnter != gameObject) return;
            DisplayerConnector.Inspect(
                CharactersData.TextByCharacter[CharacterId.None]
            );
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
