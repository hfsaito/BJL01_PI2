using UnityEngine;
using Assets.App.Investigation.Characters;

namespace Assets.App.Investigation.Screenplays.Actions
{
    [System.Serializable]
    public class Idle : Base
    {
        public float IdleTimeSeconds;
        private float targetTime = -1f;

        override public bool Run(Character character)
        {
            if (targetTime < 0) {
                targetTime = Time.time + IdleTimeSeconds;
                character.Idle();
            }
            return Time.time > targetTime;
        }
    }
}
