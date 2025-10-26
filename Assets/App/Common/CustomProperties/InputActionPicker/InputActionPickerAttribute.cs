using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.App.Common.CustomProperties.InputActionPicker
{
    public class InputActionPickerAttribute : PropertyAttribute
    {
        public InputActionType inputActionType;
        public string controlType;

        public InputActionPickerAttribute(InputActionType inputActionType)
        {
            this.inputActionType = inputActionType;
            controlType = "";
        }

        public InputActionPickerAttribute(InputActionType inputActionType, Type controlType)
        {
            this.inputActionType = inputActionType;
            this.controlType = controlType.Name;
        }
    }
}