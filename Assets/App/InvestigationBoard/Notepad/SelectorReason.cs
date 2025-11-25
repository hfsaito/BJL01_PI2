using UnityEngine;
using UnityEngine.UI;
using TMPro;

using Assets.App.Common.Data;

namespace Assets.App.InvestigationBoard.Notepad
{
    public class SelectorReason : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textMeshPro;
        [SerializeField] private Button buttonPrev;
        [SerializeField] private Button buttonNext;

        private ReasonId[] notepadOptions;
        private int selectedIndex = 0;

        void Start()
        {
            textMeshPro.text = "";
            notepadOptions = ReasonsData.NotepadOptions();
            selectedIndex = System.Array.FindIndex(
                notepadOptions,
                option => option == NotepadData.GetReason()
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
            textMeshPro.text = ReasonsData.GetNotepadLabel(notepadOptions[selectedIndex]);
            NotepadData.UpdateReason(notepadOptions[selectedIndex]);
        }
    }
}