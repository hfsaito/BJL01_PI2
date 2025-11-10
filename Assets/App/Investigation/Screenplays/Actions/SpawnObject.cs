using Assets.App.Investigation.Characters;
using UnityEngine;

namespace Assets.App.Investigation.Screenplays.Actions
{
    [System.Serializable]
    public class SpawnObject : Base
    {
        public GameObject Position;
        public GameObject ObjectToSpawn;

        override public bool Run(Character _)
        {
            Object.Instantiate(ObjectToSpawn, Position.transform.position, Quaternion.identity);
            return true;
        }
    }
}
