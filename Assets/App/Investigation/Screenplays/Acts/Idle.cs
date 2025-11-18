using UnityEngine;
using Assets.App.Investigation.Characters;

namespace Assets.App.Investigation.Screenplays.Acts
{
    [System.Serializable]
    public class Idle : Base
    {
        [SerializeField] private float IdleTimeSeconds;
        private float targetTime = -1f;

        override protected ActState Initialize(Character character)
        {
            targetTime = Time.time + IdleTimeSeconds;
            character.Idle();
            return ActState.RUNNING;
        }

        override protected ActState Run(Character character)
        {
            if (Time.time > targetTime) return ActState.DONE;
            else                        return ActState.RUNNING;
        }
    }
}
