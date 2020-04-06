using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceAndChaos
{

    public class GameController : MonoBehaviour
    {
        public InitialConditions initialConditions;
        public GameObject specimen;

        public bool lockSpecimen = false;
        private GameObject activeSpecimen = null;
        private Rigidbody rb = null;

        private void SetInitialConditions()
        {
            InitialConditionsSetter.Set(activeSpecimen, initialConditions);
        }

        public void Start()
        {
            initialConditions = new InitialConditions()
            {
                Position = transform.position,
                Velocity = new Vector3(10, 0, 0)
            };
        }

        public void Spawn()
        {
            Destroy(activeSpecimen);
            lockSpecimen = false;
            activeSpecimen = SpecimenSpawner.Spawn(specimen, transform);
            SetInitialConditions();
        }

        public void Roll()
        {
            lockSpecimen = true;
            SetInitialConditions();
            SpecimenRoller.Roll(activeSpecimen);
        }

        public void Rotate(float x, float y, float z)
        {
            initialConditions.Rotation = Quaternion.Euler(x, y, z);
            if(!lockSpecimen) SetInitialConditions();
        }


        void Update()
        {
            SpecimenStopper.IsStopped(activeSpecimen);
        }

    }

}