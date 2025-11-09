using UnityEngine;

using Assets.App.Investigation.Characters;

namespace Assets.App.Investigation.Screenplays.Actions
{
    [System.Serializable]
    public class Move : Base
    {
        public GameObject Destination;

        private bool initialized = false;
        override public bool Run(Character character)
        {
            if (!initialized)
            {
                initialized = true;
                character.Move(Destination.transform.position);
            }

            return Destination.transform.position == character.transform.position;
        }
    }
}
