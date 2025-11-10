using Assets.App.Investigation.Characters;
using UnityEngine;

namespace Assets.App.Investigation.Screenplays.Actions
{
    [System.Serializable]
    public class Look : Base
    {
        public GameObject Destination;

        override public bool Run(Character character)
        {
            character.Look(Destination.transform.position);
            return true;
        }
    }
}
