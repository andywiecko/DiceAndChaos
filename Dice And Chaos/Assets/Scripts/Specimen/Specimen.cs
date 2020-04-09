using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceAndChaos
{

    public class Specimen
    {
        public Rigidbody Rigidbody { get; set; }
        public bool IsActive { get; set; }
        public GameObject GameObject { get; set; } = null;

        InitialConditions initialConditions;
        public InitialConditions InitialConditions
        {
            get => initialConditions;
            set
            {
                initialConditions = value;
                GameObject.transform.position = InitialConditions.Position;
                GameObject.transform.rotation = InitialConditions.Rotation;
                Rigidbody.velocity = InitialConditions.Velocity;
                Rigidbody.angularVelocity = InitialConditions.AngularVelocity;
            }
        }

        public Specimen(GameObject gameObject)
        {
            GameObject = gameObject;
            Rigidbody = GameObject.GetComponent<Rigidbody>();
        }

    }

}