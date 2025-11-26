using UnityEngine;

namespace Assets.App.Investigation.Characters
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    public class Character : MonoBehaviour
    {
        private Rigidbody2D c_rigidbody2d;
        private Animator c_animator;

        private Vector2 destination, direction;
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

        private void FixedUpdate_Move()
        {
            if (destination == null) return;

            if (c_rigidbody2d.linearVelocity.magnitude * Time.fixedDeltaTime > Vector2.Distance(destination, transform.position))
            {
                c_rigidbody2d.position = destination;
                c_rigidbody2d.linearVelocity = Vector2.zero;
            }
        }

        public void Idle()
        {
            if (!gameObject.activeSelf)
            {
                return;
            }
            c_animator.SetBool("Walking", false);
        }

        public void Move(Vector2 newDestination)
        {
            if (!gameObject.activeSelf)
            {
                return;
            }
            destination = newDestination;
            direction = (destination - (Vector2)transform.position).normalized;

            c_rigidbody2d.linearVelocity = direction * WALK_SPEED;
            c_animator.SetBool("Walking", true);
            c_animator.SetFloat("DirectionX", direction.x);
            c_animator.SetFloat("DirectionY", direction.y);
        }

        public void Look(Vector2 position)
        {
            if (!gameObject.activeSelf)
            {
                return;
            }
            direction = (position - (Vector2)transform.position).normalized;
            c_animator.SetBool("Walking", false);
            c_animator.SetFloat("DirectionX", direction.x);
            c_animator.SetFloat("DirectionY", direction.y);
        }
    }
}