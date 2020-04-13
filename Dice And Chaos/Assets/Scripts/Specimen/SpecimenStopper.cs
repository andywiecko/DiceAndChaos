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

        private static void UpdateLastTransforms(Specimen specimen)
        {
            int N = specimen.lastTransforms.Length;
            for (int i = 0; i < N - 1; i++)
                specimen.lastTransforms[i] = specimen.lastTransforms[i + 1];
            specimen.lastTransforms[N - 1] = specimen.Rigidbody.velocity;
        }

        private static bool CheckLastTransforms(Specimen specimen)
        {
            foreach (var velocity in specimen.lastTransforms)
            {
                if (velocity != Vector3.zero)
                    return false;
            }
            return true;
        }

        public static bool IsStopped(Specimen specimen)
        {
            
            UpdateLastTransforms(specimen);
            if (CheckLastTransforms(specimen) && !messageRecived)
            {
                //Debug.Log("Body stopped!");
                
                return true;
            }
            return false;
        }

        public static string GetTheResult(Specimen specimen)
        {
            messageRecived = true;
            string maxname = FindHighestFace(specimen.GameObject.transform);
            Debug.Log($"You roll { maxname }!");
            return maxname;
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