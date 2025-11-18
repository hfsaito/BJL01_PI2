using UnityEngine;

using Assets.App.Investigation.Characters;

namespace Assets.App.Investigation.Screenplays.Acts
{
    [System.Serializable]
    public class ToggleObject : Base
    {
        [SerializeField] private GameObject ObjectToToggle;
        [SerializeField] private bool Active;

        override protected ActState Initialize(Character _)
        {
            ObjectToToggle.SetActive(Active);
            return ActState.DONE;
        }
    }
}
