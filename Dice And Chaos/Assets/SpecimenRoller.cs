using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceAndChaos
{
    public class SpecimenRoller
    {
        static public void Roll(GameObject specimen)
        {
            Rigidbody rb = specimen.GetComponent<Rigidbody>();
            rb.useGravity = true;
            rb.isKinematic = false;
        }
    }
}