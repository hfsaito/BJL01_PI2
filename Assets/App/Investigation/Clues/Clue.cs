using UnityEngine;

namespace Assets.App.Investigation.Clues
{
    public class Clue : MonoBehaviour
    {
        [SerializeField] private string clueName;
        [HideInInspector] public string ClueName { get { return clueName; } set {} }
        private bool alreadyCaptured = false;

        public void Capture()
        {
            if (alreadyCaptured) return;
            alreadyCaptured = true;

            // System.IO.Directory.CreateDirectory("ObserverClues");
            // ScreenCapture.CaptureScreenshot($"ObserverClues/{ClueName}.png");

            Globals.ClueFound(this);
        }
    }
}
