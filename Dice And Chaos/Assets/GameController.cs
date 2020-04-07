using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceAndChaos
{

    public class GameController : MonoBehaviour
    {
        /// <summary>
        /// Specimen GameObject to spawn
        /// </summary>
        public GameObject specimenGameObject;

        private GameObject specimenGameObjectRef = null;
        private Specimen specimen = null;
        private InitialConditions initialConditions;

        private void SetInitialConditions()
        {
            InitialConditionsSetter.Set(specimen, initialConditions);
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
            //lockSpecimen = false;
            Destroy(specimenGameObjectRef);
            specimenGameObjectRef = SpecimenSpawner.Spawn(ref specimen, transform);
            
            SetInitialConditions();
        }

        public void Roll()
        {
            //lockSpecimen = true;
            SetInitialConditions();
            SpecimenRoller.Roll(specimen);
        }

        public void Rotate(float x, float y, float z)
        {
            initialConditions.Rotation = Quaternion.Euler(x, y, z);
            //if(!lockSpecimen) SetInitialConditions();
        }


        void Update()
        {
            //SpecimenStopper.IsStopped(activeSpecimen);
        }

    }

}