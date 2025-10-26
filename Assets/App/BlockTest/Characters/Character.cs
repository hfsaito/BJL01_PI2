using Assets.App.BlockTest.Screenplays.Actions;
using UnityEngine;

namespace Assets.App.BlockTest.Characters
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Character : MonoBehaviour
    {
        // [SerializeField]
        // private Waypoint initialWaypoint;
        // private Waypoint currentWaypoint;

        // [SerializeField]
        // private GameObject clue;

        private Rigidbody2D c_rigidbody2d;

        private ScreenplayAction currentAction;
        private Vector2 destination, distance, velocity;
        private readonly float WALK_SPEED = .5f;

        void Start()
        {
            c_rigidbody2d = GetComponent<Rigidbody2D>();
        //     currentWaypoint = initialWaypoint;
        //     clue.SetActive(false);
        }

        // void Update()
        // {
        //     if (currentWaypoint == null) return;
        //     distance = (Vector2)currentWaypoint.transform.position - (Vector2)transform.position;
        //     if (distance.magnitude < .1f)
        //     {
        //         currentWaypoint = currentWaypoint.NextWaypoint();
        //         clue.SetActive(currentWaypoint != null && currentWaypoint.Action() == "clue");
        //     }
        // }

        void FixedUpdate()
        {
            FixedUpdate_Move();
        }

        #region MOVE
        public void SetMove(ScreenplayAction action)
        {
            currentAction = action;
            velocity = (action.transform.position - transform.position).normalized * WALK_SPEED;
            destination = action.transform.position;
        }

        private void FixedUpdate_Move()
        {
            if (currentAction == null || currentAction.Type != ScreenplayActionType.MOVE_HERE) return;

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

        public void ClearAction()
        {
            currentAction = null;
        }
    }
}