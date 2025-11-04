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
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("IdleTime"));
                    break;
                case ScreenplayActionType.OBJECT_TOGGLE_ACTIVE:
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("ObjectToToggle"));
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("Activate"));
                    break;
                case ScreenplayActionType.SPAWN_OBJECT:
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("ObjectToSpawn"));
                    break;
                default:
                    break;
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
#endif
