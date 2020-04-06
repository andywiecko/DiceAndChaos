using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceAndChaos
{

    public class Specimen
    {
        private GameObject gameObject;
        private Rigidbody rigidbody;

        public GameObject GameObject { get => gameObject; set => gameObject = value; }
        public Rigidbody Rigidbody { get => rigidbody; set => rigidbody = value; }

        public Specimen(GameObject _gameObject)
        {
            GameObject = _gameObject;
            Rigidbody = GameObject.GetComponent<Rigidbody>();
        }

    }

}