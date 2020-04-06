using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceAndChaos
{

    public class SpecimenStopper
    {
        private static bool messageRecived = false;

        public static void IsStopped(GameObject specimen)
        {
            Rigidbody rb = specimen.GetComponent<Rigidbody>();
            if (rb.velocity == Vector3.zero && !messageRecived)
            {
                Debug.Log("Body stopped!");
                messageRecived = true;

                //string maxname = FindHighestFace(specimen.transform);
                //Debug.Log($"You roll { maxname }!");

            }
        }
    }

}