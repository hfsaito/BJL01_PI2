using Assets.App.Investigation.Characters;
using UnityEngine;

namespace Assets.App.Investigation.Screenplays.Actions
{
    public enum ScreenplayActionType
    {
        IDLE,
        MOVE,
        LOOK,
        TOGGLE_OBJECT,
        SPAWN_OBJECT,
    }

    [CreateAssetMenu(fileName = "ScreenplayAction", menuName = "Scriptable Objects/ScreenplayAction")]
    public class ScreenplayAction : ScriptableObject
    {
        public bool Completed { get; private set; }
        public ScreenplayActionType Type;

        [SerializeField] private Idle idle;
        [SerializeField] private Move move;
        [SerializeField] private Look look;
        [SerializeField] private ToggleObject toggleObject;
        [SerializeField] private SpawnObject spawnObject;

        public void Run(Character character)
        {
            Completed = Type switch
            {
                ScreenplayActionType.IDLE => idle.Run(character),
                ScreenplayActionType.MOVE => move.Run(character),
                ScreenplayActionType.LOOK => look.Run(character),
                ScreenplayActionType.TOGGLE_OBJECT => toggleObject.Run(character),
                ScreenplayActionType.SPAWN_OBJECT => spawnObject.Run(character),
                _ => throw new System.NotImplementedException($"ScreenplayActionType not implemented: {Type}"),
            };
        }
    }
}
