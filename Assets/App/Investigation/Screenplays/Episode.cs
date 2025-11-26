using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.App.Investigation.Screenplays
{
    public class Episode : MonoBehaviour
    {
        private int screenplayCount;
        private Screenplay c_screenplay;
        [HideInInspector] public event System.Action OnEnd;

        public void Play()
        {
            foreach (Transform child in transform)
            {
                c_screenplay = child.GetComponent<Screenplay>();
                if (c_screenplay != null)
                {
                    screenplayCount++;
                    c_screenplay.OnEnd += HandleScreenplayEnd;
                    c_screenplay.Play();
                }
            }
        }

        private void HandleScreenplayEnd()
        {
            screenplayCount--;
            if (screenplayCount == 0)
            {
                OnEnd.Invoke();
            }
        }
    }
}
