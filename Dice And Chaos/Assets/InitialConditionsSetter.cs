using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceAndChaos
{

    public class InitialConditionsSetter
    {
        public static void Set(GameObject specimen, InitialConditions initialConditions)
        {
            specimen.transform.position = initialConditions.Position;
            specimen.transform.rotation = initialConditions.Rotation;
            Rigidbody rb = specimen.GetComponent<Rigidbody>();
            rb.velocity = initialConditions.Velocity;
            rb.angularVelocity = initialConditions.AngularVelocity;
        }

    }

}