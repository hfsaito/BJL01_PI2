using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.App.Menu
{
    [RequireComponent(typeof(Button))]
    public class Play : MonoBehaviour
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
            SceneManager.LoadScene("StoryTransition 1");
        }
    }
}
