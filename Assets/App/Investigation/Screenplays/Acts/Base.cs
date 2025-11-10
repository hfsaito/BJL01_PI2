using UnityEngine;
using Assets.App.Investigation.Characters;

namespace Assets.App.Investigation.Screenplays.Acts
{
    public enum ActState
    {
        INITIALIZABLE,
        RUNNING,
        DONE,
    }

    public class Base : MonoBehaviour
    {
        [HideInInspector] public ActState State;

        public void ActUpdate(Character character)
        {
            State = State switch
            {
                ActState.INITIALIZABLE => Initialize(character),
                ActState.RUNNING => Run(character),
                // ActState.DONE => End(character),
                _ => throw new System.NotImplementedException($"ActState not implemented: {State}"),
            };
        }

        virtual public ActState Initialize(Character character)
        {
            throw new System.NotImplementedException("Missing");
        }

        virtual public ActState Run(Character character)
        {
            throw new System.NotImplementedException("Missing");
        }

        // virtual public ActState End(Character character)
        // {
        //     return ActState.DONE;
        // }
    }
}
