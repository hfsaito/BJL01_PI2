using System;
using UnityEditor;
using UnityEngine;

namespace Assets.App.Common.CustomProperties.Vector2WithLimits
{
    [CustomPropertyDrawer(typeof(Vector2WithLimitsAttribute))]
    public class Vector2WithLimitsDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.Vector2)
            {
                EditorGUI.LabelField(position, label.text, "Use Vector2WithLimits with Vector2 fields");
                return;
            }

            var typedAttribute = (Vector2WithLimitsAttribute)attribute;

            EditorGUI.BeginChangeCheck();
            var newValue = EditorGUI.Vector2Field(position, label, property.vector2Value);
            newValue.x = Math.Clamp(newValue.x, typedAttribute.MinX, typedAttribute.MaxX);
            newValue.y = Math.Clamp(newValue.y, typedAttribute.MinY, typedAttribute.MaxY);
            if (EditorGUI.EndChangeCheck())
            {
                property.vector2Value = newValue;
            }
        }
    }
}