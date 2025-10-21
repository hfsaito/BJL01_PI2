using UnityEngine;

namespace Assets.App.BlockTest.Scripts
{
    public class Waypoint : MonoBehaviour
    {
        [SerializeField]
        private Waypoint nextWaypoint;
        [SerializeField]
        private string action;

        public Waypoint NextWaypoint()
        {
            return nextWaypoint;
        }

        public string Action()
        {
            return action;
        }
    }
}
