using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.App.StoryTransition
{
    public class StoryTextManager : MonoBehaviour
    {
        [SerializeField] private Image foregroundImage;
        [SerializeField] private TMP_Text tmpText;


        private List<string> texts = new()
        {
@"<color=#8B7D62>Rosiane Freitas</color> sumiu no dia 13 de Maio de 1964 próximo a ponte da cidade

Deixou uma carta escrita por uma <color=red>máquina de datilografia</color> dentro de seu carro abandonado",
@"Após 3 dias sem achar o corpo.

A policia desiste das buscas.

O <color=#8B7D62>viúvo</color> providencia um funeral",
@"20 de Maio de 1964

A policia acha um <color=red>pano de seda contendo sangue</color> em um copartimento de difícil acesso no carro",
@"O <color=#8B7D62>viúvo</color> é levado a delegacia

Ele é um homem muito influente, não sairá preso com poucas provas",
        };
        private InputSystem_Actions input;
        private int textIndex = 0;

        void Awake()
        {
            input = new();
        }

        void OnEnable()
        {
            input.Enable();
            input.Observer.Continue.performed += HandleContinue;
        }

        void OnDisable()
        {
            input.Disable();
            input.Observer.Continue.performed -= HandleContinue;
        }

        void Start()
        {
            UpdateText();
        }

        private void HandleContinue(InputAction.CallbackContext _context)
        {
            if ((textIndex + 1) < texts.Count())
            {
                textIndex++;
                StartCoroutine(TempDisableInput());
            } else
            {
                string nextSceneName = $"InvestigationNight";
                SceneManager.LoadScene(nextSceneName);
            }
        }

        private static readonly WaitForSeconds TIME_INPUT_DISABLE = new(.5f);
        private IEnumerator TempDisableInput()
        {
            var color = foregroundImage.color;
            color.a = 1f;
            foregroundImage.color = color;
            input.Disable();
            UpdateText();
            yield return TIME_INPUT_DISABLE;
            color = foregroundImage.color;
            color.a = 0f;
            foregroundImage.color = color;
            input.Enable();
        }

        private void UpdateText()
        {
            if (textIndex >= 0 && textIndex < texts.Count())
            {
                tmpText.text = texts[textIndex];
                LayoutRebuilder.ForceRebuildLayoutImmediate(tmpText.rectTransform);
            }
        }
    }
}
