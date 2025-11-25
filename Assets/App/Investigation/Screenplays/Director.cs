using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.App.Investigation.Screenplays
{
    public class Director : MonoBehaviour
    {
        [SerializeField] private string nextSceneName;
        private int screenplayCount;
        private Screenplay c_screenplay;
        void Start()
        {
            Time.timeScale = 5f;
            foreach (Transform child in transform)
            {
                c_screenplay = child.GetComponent<Screenplay>();
                if (c_screenplay != null)
                {
                    screenplayCount++;
                    c_screenplay.OnFinish += HandleScreenplayFinish;
                }
            }
        }

        private void HandleScreenplayFinish()
        {
            screenplayCount--;
            if (screenplayCount == 0)
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
}
