using UnityEditor;

#if UNITY_EDITOR
namespace Assets.App.BlockTest.Screenplays.Actions
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
                case ScreenplayActionType.PLAY_ANIMATION:
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("AnimtaionToPlay"));
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("AnimationTime"));
                    action.ObjectToSpawn = null;
                    break;
                case ScreenplayActionType.SPAWN_OBJECT:
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("ObjectToSpawn"));
                    action.AnimtaionToPlay = "";
                    action.AnimationTime = 0;
                    break;
                default:
                    break;
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
#endif
