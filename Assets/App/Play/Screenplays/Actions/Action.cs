using System.Collections;

using UnityEngine;

using Assets.App.BlockTest.Characters;
using System;
using System.Linq;

namespace Assets.App.BlockTest.Screenplays.Actions
{
    public enum ScreenplayActionType
    {
        MOVE_HERE,
        PLAY_ANIMATION,
        SPAWN_OBJECT,
    }

    public class ScreenplayAction : MonoBehaviour
    {
        public ScreenplayActionType Type;
        public event Action OnEnd;

        void OnDestroy()
        {
            foreach(var action in OnEnd.GetInvocationList().Cast<Action>())
            {
                OnEnd -= action;
            }
        }

        public void Run(Character character)
        {
            switch (Type)
            {
                case ScreenplayActionType.MOVE_HERE:
                    MoveHere(character);
                    break;
                case ScreenplayActionType.PLAY_ANIMATION:
                    Animate(character);
                    break;
                case ScreenplayActionType.SPAWN_OBJECT:
                    SpawnObject();
                    break;
                default:
                    character.ClearAction();
                    break;
            }
        }

        public void End()
        {
            StartCoroutine(AsyncEnd());
        }

        private IEnumerator AsyncEnd()
        {
            yield return new WaitForEndOfFrame();
            OnEnd.Invoke();
            Destroy(this);
        }

        #region MOVE_HERE
        private void MoveHere(Character character)
        {
            character.SetMove(this);
        }
        #endregion

        #region PLAY_ANIMATION
        public string AnimtaionToPlay;
        public float AnimationTime;

        private void Animate(Character character)
        {
            character.SetAnimation(AnimtaionToPlay);
            StartCoroutine(AnimateEnd());
        }

        private IEnumerator AnimateEnd()
        {
            yield return new WaitForSeconds(AnimationTime);
            End();
        }
        #endregion

        #region SPAWN_OBJECT
        public GameObject ObjectToSpawn;

        private void SpawnObject()
        {
            if (ObjectToSpawn != null)
            {
                Instantiate(
                    ObjectToSpawn,
                    transform.position,
                    new Quaternion()
                );
            }
            End();
        }
        #endregion
    }
}
