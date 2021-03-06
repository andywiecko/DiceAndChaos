﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceAndChaos
{

    public class InitialConditionSwitcher
    {
        static public void SwitchFields(FieldsHandler.Type type, float  value, ref InitialConditions initialConditions)
        {
            Vector3 rotation = initialConditions.RotationVector;
            Vector3 velocity = initialConditions.Velocity;
            Vector3 angularVelocity = initialConditions.AngularVelocity;

            switch (type)
            {
                // Rotation
                case FieldsHandler.Type.RotX:
                    rotation.x = value;
                    break;
                case FieldsHandler.Type.RotY:
                    rotation.y = value;
                    break;
                case FieldsHandler.Type.RotZ:
                    rotation.z = value;
                    break;

                // Velocity
                case FieldsHandler.Type.VelX:
                    velocity.x = value;
                    break;
                case FieldsHandler.Type.VelY:
                    velocity.y = value;
                    break;
                case FieldsHandler.Type.VelZ:
                    velocity.z = value;
                    break;

                // Angular Velocity
                case FieldsHandler.Type.AngVelX:
                    angularVelocity.x = value;
                    break;
                case FieldsHandler.Type.AngVelY:
                    angularVelocity.y = value;
                    break;
                case FieldsHandler.Type.AngVelZ:
                    angularVelocity.z = value;
                    break;
            }

            initialConditions.RotationVector = rotation;
            initialConditions.Velocity = velocity;
            initialConditions.AngularVelocity = angularVelocity;
            //Debug.Log(initialConditions.ToString());
        }
    }

}

