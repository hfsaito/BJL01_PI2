using UnityEngine;

using Assets.App.Investigation.Characters;

namespace Assets.App.Investigation.Screenplays.Acts
{
    [System.Serializable]
    public class Move : Base
    {
        override public ActState Initialize(Character character)
        {
            character.Move(transform.position);
            return ActState.RUNNING;
        }

        override public ActState Run(Character character)
        {
            if (transform.position == character.transform.position) return ActState.DONE;
            else return ActState.RUNNING;
        }
    }
}
