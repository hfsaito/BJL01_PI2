using Assets.App.Investigation.Characters;

namespace Assets.App.Investigation.Screenplays.Acts
{
    public class InstantMove : Base
    {
        override protected ActState Initialize(Character character)
        {
            character.transform.position = transform.position;
            return ActState.DONE;
        }
    }
}
