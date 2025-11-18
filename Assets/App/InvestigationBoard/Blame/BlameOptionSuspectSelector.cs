using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BlameOptionSuspectSelector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private Button buttonPrev;
    [SerializeField] private Button buttonNext;

    void Start()
    {
        BlameData.UpdateAvailableValues();
        buttonPrev.onClick.AddListener(PrevOptionSuspect);
        buttonNext.onClick.AddListener(NextOptionSuspect);
    }

    void OnDisable()
    {
        buttonPrev.onClick.RemoveListener(PrevOptionSuspect);
        buttonNext.onClick.RemoveListener(NextOptionSuspect);
    }

    private void PrevOptionSuspect()
    {
        BlameData.SelectPrevSuspectByIndex();
        textMeshPro.text = BlameData.GetSuspectLabel();
    }

    private void NextOptionSuspect()
    {
        BlameData.SelectNextSuspectByIndex();
        textMeshPro.text = BlameData.GetSuspectLabel();
    }
}
