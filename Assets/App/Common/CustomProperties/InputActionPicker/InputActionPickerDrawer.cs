using System;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

#if UNITY_EDITOR
namespace Assets.App.Common.CustomProperties.InputActionPicker
{
    [CustomPropertyDrawer(typeof(InputActionPickerAttribute))]
    public class InputActionPickerDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.String)
            {
                EditorGUI.LabelField(position, label.text, "Use InputActionPicker with string fields");
                return;
            }

            var actionFilters = (InputActionPickerAttribute)attribute;

            InputAction[] actions = InputSystem.actions.actionMaps
                .SelectMany(actionMap => actionMap.actions)
                .Where(action =>
                {
                    return action.type == actionFilters.inputActionType &&
                        (
                            actionFilters.controlType.Length == 0 ||
                            action.expectedControlType == actionFilters.controlType
                        );
                })
                .ToArray();
            string[] actionIds = actions
                .Select(action => action.id.ToString())
                .ToArray();
            string[] actionNames = actions
                .Select(action => string.Join("/", new[] { action.actionMap.name, action.name }))
                .ToArray();

            int currentIndex = Array.IndexOf(actionIds, property.stringValue);
            int newIndex = EditorGUI.Popup(position, label.text, currentIndex, actionNames);

            if (newIndex >= 0 && newIndex < actionNames.Length)
            {
                property.stringValue = actionIds[newIndex];
            }
        }
    }
}
#endif
