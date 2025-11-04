using System.Collections;

using UnityEngine;

using Assets.App.Investigation.Characters;
using System;
using System.Linq;

namespace Assets.App.Investigation.Screenplays.Actions
{
    public enum ScreenplayActionType
    {
        IDLE,
        MOVE,
        LOOK_AT,
        OBJECT_TOGGLE_ACTIVE,
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
                case ScreenplayActionType.IDLE:
                    MoveHere(character);
                    break;
                case ScreenplayActionType.MOVE:
                    MoveHere(character);
                    break;
                case ScreenplayActionType.LOOK_AT:
                    LookHere(character);
                    break;
                case ScreenplayActionType.OBJECT_TOGGLE_ACTIVE:
                    LookHere(character);
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

        #region IDLE
        public float IdleTime;

        private void Animate(Character character)
        {
            character.Idle();
            StartCoroutine(IdleEnd());
        }

        private IEnumerator IdleEnd()
        {
            yield return new WaitForSeconds(IdleTime);
            End();
        }
        #endregion

        #region MOVE
        private void MoveHere(Character character)
        {
            character.SetMove(this);
        }
        #endregion

        #region LOOK_AT
        private void LookHere(Character character)
        {
            character.SetLookAt(transform.position);
            End();
        }
        #endregion

        #region OBJECT_TOGGLE_ACTIVE
        public GameObject ObjectToToggle;
        public bool Activate;

        private void ToggleObjectActive()
        {
            if (ObjectToToggle != null)
            {
                ObjectToToggle.SetActive(Activate);
            }
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
