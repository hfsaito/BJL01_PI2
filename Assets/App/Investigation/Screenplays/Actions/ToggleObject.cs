using Assets.App.Investigation.Characters;
using UnityEngine;

namespace Assets.App.Investigation.Screenplays.Actions
{
    [System.Serializable]
    public class ToggleObject : Base
    {
        public GameObject ObjectToToggle;
        public bool Active;

        override public bool Run(Character _)
        {
            ObjectToToggle.SetActive(Active);
            return true;
        }
    }
}
