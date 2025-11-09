using UnityEditor;

#if UNITY_EDITOR
namespace Assets.App.Investigation.Screenplays.Actions
{
    [CustomEditor(typeof(ScreenplayAction))]
    public class ScreenplayActionEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            ScreenplayAction action = (ScreenplayAction)target;

            EditorGUILayout.PropertyField(serializedObject.FindProperty("Type"));

            switch (action.Type)
            {
                case ScreenplayActionType.IDLE:
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("idle"), true);
                    break;
                case ScreenplayActionType.MOVE:
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("move"), true);
                    break;
                case ScreenplayActionType.LOOK:
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("look"), true);
                    break;
                case ScreenplayActionType.TOGGLE_OBJECT:
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("toggleObject"), true);
                    break;
                case ScreenplayActionType.SPAWN_OBJECT:
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("spawnObject"), true);
                    break;
                default:
                    break;
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
#endif
