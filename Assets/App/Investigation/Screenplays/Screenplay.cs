using UnityEngine;

using Assets.App.Investigation.Characters;
using Assets.App.Investigation.Screenplays.Actions;

namespace Assets.App.Investigation.Screenplays
{
    public class Screenplay : MonoBehaviour
    {

        [SerializeField] private ScreenplayAction[] actions;
        [SerializeField] private Character character;

        private int actionIndex;

        void Update()
        {
            if (actionIndex >= actions.Length) return;
            actions[actionIndex].Run(character);
            if (actions[actionIndex].Completed) actionIndex++;
        }
    }
}
