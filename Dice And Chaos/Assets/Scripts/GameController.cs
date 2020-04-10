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
        public InitialConditions initialConditions;

        private ArrowViewer arrowViewer;

        private bool isInSpawn = false;

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
            isInSpawn = true;
            Destroy(specimenGameObjectRef);
            specimenGameObjectRef = SpecimenSpawner.Spawn(ref specimen, transform);
            SetInitialConditions();
            arrowViewer.SetArrowsActive(true);
            arrowViewer.SetVelocityArrow(initialConditions.Velocity);
            arrowViewer.SetAngularVelocityArrow(initialConditions.AngularVelocity);
        }

        public void Roll()
        {
            isInSpawn = false;
            SpecimenStopper.Reset();
            arrowViewer.Reset();
            SetInitialConditions();
            SpecimenRoller.Roll(specimen);
        }

        public bool IsActive()
        {
            return specimen.IsActive;
        }

        public void Rotate(float x, float y, float z)
        {
            initialConditions.Rotation = Quaternion.Euler(x, y, z);
            if (!specimen.IsActive && isInSpawn) SetInitialConditions();
        }

        public void SetVelocity(float x, float y, float z)
        {
            initialConditions.Velocity = new Vector3(x, y, z);
            if (!specimen.IsActive && isInSpawn)
            {
                SetInitialConditions();
                arrowViewer.SetVelocityArrow(initialConditions.Velocity);
            }
        }

        public void SetAngularVelocity(float x, float y, float z)
        {
            initialConditions.AngularVelocity = new Vector3(x, y, z);
            if (!specimen.IsActive && isInSpawn)
            {
                SetInitialConditions();
                arrowViewer.SetAngularVelocityArrow(initialConditions.AngularVelocity);
            }
        }

        void Update()
        {
            if(SpecimenStopper.IsStopped(specimen))
            {
                specimen.IsActive = false;
            }
        }

    }

}