using UnityEngine;

using Assets.App.Investigation.Characters;

namespace Assets.App.Investigation.Screenplays.Acts
{
    [System.Serializable]
    public class SpawnObject : Base
    {
        [SerializeField] private GameObject ObjectToSpawn;

        override public ActState Initialize(Character _)
        {
            Instantiate(ObjectToSpawn, transform.position, Quaternion.identity);
            return ActState.DONE;
        }
    }
}
