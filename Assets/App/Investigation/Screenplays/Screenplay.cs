using System;

using UnityEngine;

using Assets.App.Investigation.Characters;

namespace Assets.App.Investigation.Screenplays
{
    public class Screenplay : MonoBehaviour
    {
        [SerializeField] private Character character;

        private int actIndex;
        private Acts.Base currentAct;

        [HideInInspector] public event Action OnEnd;
        private bool running = false;

        void Update()
        {
            if (!running)
            {
                return;
            }

            if (actIndex >= transform.childCount)
            {
                running = false;
                OnEnd.Invoke();
                return;
            }

            currentAct = transform.GetChild(actIndex).GetComponent<Acts.Base>();
            if (currentAct) currentAct.ActUpdate(character);
            if (!currentAct || currentAct.State == Acts.ActState.DONE) actIndex++;
        }

        public void Play()
        {
            if (transform.childCount == 0)
            {
                return;
            }
            actIndex = 0;
            running = true;
        }
    }
}
