using Assets.App.Investigation.Characters;
using UnityEngine;

namespace Assets.App.Investigation.Screenplays.Acts
{
    [System.Serializable]
    public class Look : Base
    {
        override protected ActState Initialize(Character character)
        {
            character.Look(transform.position);
            return ActState.DONE;
        }
    }
}
