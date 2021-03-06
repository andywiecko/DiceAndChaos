﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DiceAndChaos
{

    public class FieldsHandler : MonoBehaviour
    {
        public enum Type
        {
            RotX, RotY, RotZ,
            VelX, VelY, VelZ,
            AngVelX, AngVelY, AngVelZ
        };

        public Type type;

        public Toggle togle;
        public InputField startField;
        public InputField stepField;
        public InputField stopField;


        public bool ParseFields(out ParameterRange parameterRange)
        {
            if (togle.isOn &&
                float.TryParse(startField.text, out float start) &&
                float.TryParse(stepField.text, out float step) &&
                float.TryParse(stopField.text, out float stop)
                )
            {
                parameterRange = new ParameterRange(start, step, stop);
                return true;
            }
            parameterRange = new ParameterRange(0f, 0f, 0f);
            return false;
        }

        public void Lock()
        {
            startField.interactable = false;
            stepField.interactable = false;
            stopField.interactable = false;
        }

        public void Unlock()
        {
            startField.interactable = true;
            stepField.interactable = true;
            stopField.interactable = true;
        }

    }

}