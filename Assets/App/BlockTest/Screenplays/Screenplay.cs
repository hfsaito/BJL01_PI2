using UnityEngine;

using Assets.App.BlockTest.Characters;
using Assets.App.BlockTest.Screenplays.Actions;

namespace Assets.App.BlockTest.Screenplays
{
    public class Screenplay : MonoBehaviour
    {
        [SerializeField]
        private Character character;
        private int actionIndex = -1;
        private ScreenplayAction currentAction;

        void Start()
        {
            RunNextAction();
        }

        private void RunNextAction()
        {
            actionIndex++;
            if (actionIndex >= transform.childCount) return;

            currentAction = transform.GetChild(actionIndex).GetComponent<ScreenplayAction>();
            currentAction.OnEnd += RunNextAction;
            currentAction.Run(character);
        }
    }
}
