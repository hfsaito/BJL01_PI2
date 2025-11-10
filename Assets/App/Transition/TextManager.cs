using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.App.Transition
{
    [System.Serializable]
    public struct TextProperties
    {
        public GameObject reference;
        public float TimeInScreen;
    }

    public class TextManager : MonoBehaviour
    {
        [SerializeField] private List<TextProperties> textProperties;
        private readonly List<TMP_Text> c_texts = new();
        private int textIndex = 0;
        private float timeAnchor;

        [SerializeField] string sceneName;

        void Start()
        {
            foreach(var textProperty in textProperties)
            {
                c_texts.Add(textProperty.reference.GetComponentInChildren<TMP_Text>());
                c_texts.Last().alpha = 0;
            }
        }

        void Update()
        {
            if (textIndex < c_texts.Count())
            {
                if (c_texts[textIndex].alpha == 0)
                {
                    c_texts[textIndex].alpha = 1;
                    timeAnchor = Time.time + textProperties[textIndex].TimeInScreen;
                } else if (Time.time > timeAnchor)
                {
                    c_texts[textIndex].alpha = 0;
                    textIndex++;
                }
            } else
            {
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}
