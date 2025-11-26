using UnityEngine;

using Assets.App.Investigation.Characters;

namespace Assets.App.Investigation.Screenplays.Acts
{
    public class PlaySound : Base
    {
        [SerializeField] private AudioSource audioSource;

        override protected ActState Initialize(Character _)
        {
            audioSource.Play();
            return ActState.DONE;
        }
    }
}
