using System;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.App.Common.CustomProperties.InputActionMapPicker
{
    [CustomPropertyDrawer(typeof(InputActionMapPickerAttribute))]
    public class InputActionMapPickerDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.String)
            {
                EditorGUI.LabelField(position, label.text, "Use InputActionMapPicker with string fields");
                return;
            }

            string[] mapNames = InputSystem.actions.actionMaps
                .Select(actionMap => actionMap.name)
                .ToArray();

            int currentIndex = Array.IndexOf(mapNames, property.stringValue);
            int newIndex = EditorGUI.Popup(position, label.text, currentIndex, mapNames);

            if (newIndex >= 0 && newIndex < mapNames.Length)
            {
                property.stringValue = mapNames[newIndex];
            }
        }
    }
}