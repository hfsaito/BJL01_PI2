using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClueInspect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject clueDetailDisplayer;
    [SerializeField] private string clueName;
    [SerializeField] private string detailText;

    private TMP_Text clueDetailDisplayer_c_text;
    // private EventTrigger eventTrigger;
    void Start()
    {
        clueDetailDisplayer_c_text = clueDetailDisplayer.GetComponent<TMP_Text>();
        gameObject.SetActive(Globals.Clues.ContainsKey(clueName));
    }

    public void OnPointerEnter(PointerEventData _)
    {
        clueDetailDisplayer_c_text.text = detailText;
    }

    public void OnPointerExit(PointerEventData _)
    {
        clueDetailDisplayer_c_text.text = "";
    }
}
