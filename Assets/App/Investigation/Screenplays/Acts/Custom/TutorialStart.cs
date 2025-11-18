using UnityEngine;

using Assets.App.Investigation.Characters;
using Assets.App.Investigation.Observer;

namespace Assets.App.Investigation.Screenplays.Acts.Tutorial
{
    [System.Serializable]
    public class TutorialStart : Base
    {
        [SerializeField] private ObserverTutorial observerTutorial;

        override protected ActState Initialize(Character character)
        {
            observerTutorial.TutorialStart(character.gameObject);
            return ActState.DONE;
        }
    }
}
