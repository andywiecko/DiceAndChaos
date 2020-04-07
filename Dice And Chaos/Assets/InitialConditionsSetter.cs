using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceAndChaos
{

    public class InitialConditionsSetter
    {
        public static void Set(Specimen specimen,InitialConditions initialConditions)
        {
            specimen.GameObject.transform.position = initialConditions.Position;
            specimen.GameObject.transform.rotation = initialConditions.Rotation;
            specimen.Rigidbody.velocity = initialConditions.Velocity;
            specimen.Rigidbody.angularVelocity = initialConditions.AngularVelocity;
        }

    }

}