using UnityEngine;

using Assets.App.Common.Transitions;

namespace Assets.App.Investigation.Screenplays
{
    public class Director : MonoBehaviour
    {
        private Transform currentEpisodeTransform;
        private Episode currentEpisode;

        [SerializeField] private FadeTransition fadeTransition;

        void Start()
        {
            if (Globals.DayCount > transform.childCount)
            {
                HandleEpisodeEnd();
                return;
            }
            currentEpisodeTransform = transform.GetChild(Globals.DayCount - 1);
            currentEpisode = currentEpisodeTransform.GetComponent<Episode>();
            currentEpisode.OnEnd += HandleEpisodeEnd;
            currentEpisode.Play();
        }

        void OnDisable()
        {
            if (currentEpisode != null)
            {
                currentEpisode.OnEnd -= HandleEpisodeEnd;
            }
        }

        private void HandleEpisodeEnd()
        {
            fadeTransition.AsyncLoadScene("InvestigationBoard");
        }
    }
}
