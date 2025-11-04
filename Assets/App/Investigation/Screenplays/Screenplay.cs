using UnityEngine;

using Assets.App.Investigation.Characters;
using Assets.App.Investigation.Screenplays.Actions;

namespace Assets.App.Investigation.Screenplays
{
    public class Screenplay : MonoBehaviour
    {
        [SerializeField]
        private Character character;
        private int actionIndex = -1;
        private ScreenplayAction currentAction;

        void Start()
        {
            Invoke(nameof(RunNextAction), 0);
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
