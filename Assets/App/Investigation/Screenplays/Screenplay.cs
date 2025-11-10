using UnityEngine;

using Assets.App.Investigation.Characters;
// using Assets.App.Investigation.Screenplays.Acts;

namespace Assets.App.Investigation.Screenplays
{
    public class Screenplay : MonoBehaviour
    {

        [SerializeField] private Acts.Base[] acts;
        [SerializeField] private Character character;

        private int actIndex;

        void Update()
        {
            if (actIndex >= acts.Length) return;
            acts[actIndex].Run(character);
            if (acts[actIndex].State == Acts.ActState.DONE) actIndex++;
        }
    }
}
