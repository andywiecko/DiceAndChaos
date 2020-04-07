using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceAndChaos
{

    public class GameController : MonoBehaviour
    {
        // object to spawn
        public GameObject specimenGameObject;

        private GameObject specimenGameObjectRef = null;
        private Specimen specimen = null;
        private InitialConditions initialConditions;

        private void SetInitialConditions()
        {
            specimen.InitialConditions = initialConditions;
        }

        public void Start()
        {
            specimen = new Specimen(specimenGameObject);
            initialConditions = new InitialConditions()
            {
                Position = transform.position,
                Velocity = new Vector3(10, 0, 0)
            };
        }

        public void Spawn()
        {
            Destroy(specimenGameObjectRef);
            specimenGameObjectRef = SpecimenSpawner.Spawn(ref specimen, transform);
            SetInitialConditions();
        }

        public void Roll()
        {
            SpecimenStopper.Reset();
            SetInitialConditions();
            SpecimenRoller.Roll(specimen);
        }

        public void Rotate(float x, float y, float z)
        {
            initialConditions.Rotation = Quaternion.Euler(x, y, z);
            if(!specimen.IsActive) SetInitialConditions();
        }


        void Update()
        {
            SpecimenStopper.IsStopped(specimen);
        }

    }

}