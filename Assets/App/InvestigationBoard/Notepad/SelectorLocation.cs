using UnityEngine;
using UnityEngine.UI;
using TMPro;

using Assets.App.Common.Data;

namespace Assets.App.InvestigationBoard.Notepad
{
    public class SelectorLocation : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textMeshPro;
        [SerializeField] private Button buttonPrev;
        [SerializeField] private Button buttonNext;

        private LocationId[] notepadOptions;
        private int selectedIndex = 0;

        void Start()
        {
            textMeshPro.text = "";
            notepadOptions = LocationsData.NotepadOptions();
            selectedIndex = System.Array.FindIndex(
                notepadOptions,
                option => option == NotepadData.GetLocation()
            );
            buttonPrev.onClick.AddListener(PrevOptionSuspect);
            buttonNext.onClick.AddListener(NextOptionSuspect);

            buttonPrev.interactable = notepadOptions.Length > 1;
            buttonNext.interactable = notepadOptions.Length > 1;
        }

        void OnDisable()
        {
            buttonPrev.onClick.RemoveListener(PrevOptionSuspect);
            buttonNext.onClick.RemoveListener(NextOptionSuspect);
        }

        private void PrevOptionSuspect()
        {
            selectedIndex--;
            if (selectedIndex < 0) {
                selectedIndex += notepadOptions.Length;
            }
            UpdateValue();
        }

        private void NextOptionSuspect()
        {
            selectedIndex++;
            if (selectedIndex >= notepadOptions.Length) {
                selectedIndex -= notepadOptions.Length;
            }
            UpdateValue();
        }

        private void UpdateValue()
        {
            textMeshPro.text = LocationsData.GetNotepadLabel(notepadOptions[selectedIndex]);
            NotepadData.UpdateLocation(notepadOptions[selectedIndex]);
        }
    }
}