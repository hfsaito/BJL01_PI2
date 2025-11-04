using Assets.App.Investigation.Screenplays.Actions;
using UnityEngine;

namespace Assets.App.Investigation.Characters
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    public class Character : MonoBehaviour
    {
        private Rigidbody2D c_rigidbody2d;
        private Animator c_animator;

        private ScreenplayAction currentAction;
        private Vector2 destination, distance, velocity, direction;
        private readonly float WALK_SPEED = .5f;

        void Start()
        {
            c_rigidbody2d = GetComponent<Rigidbody2D>();
            c_animator = GetComponent<Animator>();
        }

        void FixedUpdate()
        {
            FixedUpdate_Move();
        }

        #region MOVE
        public void SetMove(ScreenplayAction action)
        {
            currentAction = action;
            destination = action.transform.position;
            direction = (action.transform.position - transform.position).normalized;
            velocity = direction * WALK_SPEED;

            c_animator.SetBool("Walking", true);
            c_animator.SetFloat("DirectionX", direction.x);
            c_animator.SetFloat("DirectionY", direction.y);
        }

        private void FixedUpdate_Move()
        {
            if (currentAction == null || currentAction.Type != ScreenplayActionType.MOVE) return;

            distance = destination - (Vector2)transform.position;
            if (velocity.magnitude * Time.fixedDeltaTime > distance.magnitude)
            {
                c_rigidbody2d.position = destination;
                c_rigidbody2d.linearVelocity = Vector2.zero;
                currentAction.End();
                ClearAction();
            }
            else
            {
                c_rigidbody2d.linearVelocity = velocity;
            }
        }
        #endregion

        public void Idle()
        {
            c_animator.SetBool("Walking", false);
        }

        public void SetLookAt(Vector3 position)
        {
            direction = (position - transform.position).normalized;
            c_animator.SetFloat("DirectionX", direction.x);
            c_animator.SetFloat("DirectionY", direction.y);
        }

        public void ClearAction()
        {
            currentAction = null;
        }
    }
}