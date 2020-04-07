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
        public InitialConditions InitialConditions { get; set; }

        public Specimen(GameObject gameObject)
        {
            GameObject = gameObject;
            Rigidbody = GameObject.GetComponent<Rigidbody>();
        }

    }

}