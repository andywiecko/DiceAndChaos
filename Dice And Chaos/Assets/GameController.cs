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

        private ArrowViewer arrowViewer;

        private void SetInitialConditions()
        {
            specimen.InitialConditions = initialConditions;
        }

        public void Start()
        {
            arrowViewer = GetComponent<ArrowViewer>();
            specimen = new Specimen(specimenGameObject);
            initialConditions = new InitialConditions() { Position = transform.position };
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
            arrowViewer.Reset();
            SetInitialConditions();
            SpecimenRoller.Roll(specimen);
        }

        public void Rotate(float x, float y, float z)
        {
            initialConditions.Rotation = Quaternion.Euler(x, y, z);
            if (!specimen.IsActive) SetInitialConditions();
        }

        public void SetVelocity(float x, float y, float z)
        {
            initialConditions.Velocity = new Vector3(x, y, z);
            if (!specimen.IsActive)
            {
                SetInitialConditions();
                arrowViewer.SetVelocityArrow(initialConditions.Velocity);
            }
        }

        public void SetAngularVelocity(float x, float y, float z)
        {
            initialConditions.AngularVelocity = new Vector3(x, y, z);
            if (!specimen.IsActive)
            {
                SetInitialConditions();
                //arrowViewer.SetVelocityArrow(initialConditions.Velocity);
            }
        }

        void Update()
        {
            SpecimenStopper.IsStopped(specimen);
        }

    }

}