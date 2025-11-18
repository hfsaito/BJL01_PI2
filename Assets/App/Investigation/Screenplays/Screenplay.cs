using System;

using UnityEngine;

using Assets.App.Investigation.Characters;
// using Assets.App.Investigation.Screenplays.Acts;

namespace Assets.App.Investigation.Screenplays
{
    public class Screenplay : MonoBehaviour
    {
        [SerializeField] private Character character;

        private int actIndex;
        private Acts.Base currentAct;

        [HideInInspector] public event Action OnFinish;
        private bool finished = false;

        void Update()
        {
            if (actIndex >= transform.childCount)
            {
                if (!finished)
                {
                    finished = true;
                    OnFinish.Invoke();
                }
                return;
            }
            currentAct = transform.GetChild(actIndex).GetComponent<Acts.Base>();
            if (currentAct) currentAct.ActUpdate(character);
            if (!currentAct || currentAct.State == Acts.ActState.DONE) actIndex++;
        }
    }
}
