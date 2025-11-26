using UnityEngine;

using Assets.App.Investigation.Characters;

namespace Assets.App.Investigation.Screenplays.Acts
{
    public class InstantMoveObject : Base
    {
        [SerializeField] private GameObject ObjectToMove;

        override protected ActState Initialize(Character _)
        {
            ObjectToMove.transform.position = transform.position;
            return ActState.DONE;
        }
    }
}
