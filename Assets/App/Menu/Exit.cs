using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.App.Menu
{
    [RequireComponent(typeof(Button))]
    public class Exit : MonoBehaviour
    {
        private Button button;

        void Start()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(HandleClick);
        }

        void OnDisable()
        {
            button.onClick.RemoveAllListeners();
        }

        private void HandleClick()
        {
            Application.Quit();
        }
    }
}
