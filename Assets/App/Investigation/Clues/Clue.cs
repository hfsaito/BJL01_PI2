using UnityEngine;

using Assets.App.Common.Clues;

namespace Assets.App.Investigation.Clues
{
    public class Clue : MonoBehaviour
    {
        [SerializeField] private ClueId clueId;
        private bool alreadyCaptured = false;

        public void Capture()
        {
            if (alreadyCaptured) return;
            alreadyCaptured = true;
            Globals.ClueFound(clueId);
        }
    }
}
