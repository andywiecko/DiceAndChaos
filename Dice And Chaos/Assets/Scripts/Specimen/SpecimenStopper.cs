using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceAndChaos
{

    public class SpecimenStopper
    {
        private static bool messageRecived = true;

        public static void Reset()
        {
            messageRecived = false;
        }

        public static void IsStopped(Specimen specimen)
        {
            Rigidbody rb = specimen.Rigidbody;
            if (rb.velocity == Vector3.zero && !messageRecived)
            {
                Debug.Log("Body stopped!");
                messageRecived = true;
                string maxname = FindHighestFace(specimen.GameObject.transform);
                Debug.Log($"You roll { maxname }!");

            }
        }

        private static string FindHighestFace(Transform transform)
        {
            string name = "";
            float maxheight = -1f;
            // iterate over all specimen "faces"
            foreach (Transform child in transform)
            {
                float childheigth = child.transform.position.y;

                if (maxheight < childheigth)
                {
                    maxheight = childheigth;
                    name = child.name;
                }


            }

            return name;
        }
    }

}