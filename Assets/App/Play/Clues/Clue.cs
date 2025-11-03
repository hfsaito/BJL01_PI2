using UnityEngine;

namespace Assets.App.BlockTest.Clues
{
    public class Clue : MonoBehaviour
    {
        public string Name;
        private bool alreadyCaptured = false;

        public void Capture()
        {
            if (alreadyCaptured) return;
            alreadyCaptured = true;

            System.IO.Directory.CreateDirectory("ObserverClues");
            ScreenCapture.CaptureScreenshot($"ObserverClues/{Name}.png");

            Globals.ClueFound(this);
        }
    }
}
