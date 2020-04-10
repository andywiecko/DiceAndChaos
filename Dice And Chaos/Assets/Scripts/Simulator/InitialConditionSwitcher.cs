using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceAndChaos
{

    public class InitialConditionSwitcher
    {
        static public void SwitchFields(FieldsHandler.Type type, float  value, InitialConditions initialConditions)
        {
            Vector3 rotation = new Vector3();
            Vector3 velocity = new Vector3();
            Vector3 angularVelocity = new Vector3();

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

            initialConditions.Rotation = Quaternion.Euler(rotation);
            initialConditions.Velocity = velocity;
            initialConditions.AngularVelocity = angularVelocity;
            //Debug.Log(initialConditions.ToString());
        }
    }

}

