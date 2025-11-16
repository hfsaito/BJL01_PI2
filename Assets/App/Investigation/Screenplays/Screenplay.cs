using System;

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

        [HideInInspector] public event Action OnFinish;
        private bool finished = false;

        void Update()
        {
            if (actIndex >= acts.Length)
            {
                if (!finished)
                {
                    finished = true;
                    OnFinish.Invoke();
                }
                return;
            }
            acts[actIndex].ActUpdate(character);
            if (acts[actIndex].State == Acts.ActState.DONE) actIndex++;
        }
    }
}
