using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DiceAndChaos
{
    public class SpecimenSpawner : MonoBehaviour
    {
        static public GameObject Spawn(GameObject specimen, Transform transform)
        {
            GameObject objectToSpawn = Instantiate(specimen, transform.position,transform.rotation);
            Rigidbody rb = objectToSpawn.GetComponent<Rigidbody>();
            rb.isKinematic = true;
            rb.useGravity = false;
            rb.maxAngularVelocity = 100f;
            return objectToSpawn;
        }

    }

}