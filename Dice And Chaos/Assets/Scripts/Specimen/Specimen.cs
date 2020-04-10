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

        const int numberOfFrames = 10;
        public Vector3[] lastTransforms = new Vector3[numberOfFrames];


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
            FrameInitialization();
        }

        public void FrameInitialization()
        {
            for(int i=0;i<numberOfFrames;i++)
            {
                lastTransforms[i] = new Vector3(1f, 1f, 1f);
            }
        }

    }

}