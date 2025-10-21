using UnityEngine;

namespace Assets.App.BlockTest.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Suspect : MonoBehaviour
    {
        [SerializeField]
        private Waypoint initialWaypoint;
        private Waypoint currentWaypoint;

        [SerializeField]
        private GameObject clue;

        private Rigidbody2D c_rigidbody2d;
        private Vector2 distance;
        private readonly float WALK_SPEED = .5f;

        void Start()
        {
            c_rigidbody2d = GetComponent<Rigidbody2D>();
            currentWaypoint = initialWaypoint;
            clue.SetActive(false);
        }

        void Update()
        {
            if (currentWaypoint == null) return;
            distance = (Vector2)currentWaypoint.transform.position - (Vector2)transform.position;
            if (distance.magnitude < .1f)
            {
                currentWaypoint = currentWaypoint.NextWaypoint();
                clue.SetActive(currentWaypoint.Action() == "clue");
            }
        }

        void FixedUpdate()
        {
            if (currentWaypoint == null)
            {
                c_rigidbody2d.linearVelocity = Vector2.zero;
                return;
            }
            distance = (Vector2)currentWaypoint.transform.position - (Vector2)transform.position;
            c_rigidbody2d.linearVelocity = distance.normalized * WALK_SPEED;
        }
    }
}