using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DiceAndChaos
{
    public class SpecimenSpawner : MonoBehaviour
    {
        static public GameObject Spawn(ref Specimen specimen, Transform transform)
        {
            GameObject go = Instantiate(specimen.GameObject, transform.position,transform.rotation);
            go.name = specimen.GameObject.name;
            Specimen newSpecimen = new Specimen(go);
            specimen = newSpecimen;
            specimen.GameObject = go;
            specimen.Rigidbody.isKinematic = true;
            specimen.Rigidbody.useGravity = false;
            specimen.Rigidbody.maxAngularVelocity = 100f;
            return go;
        }

    }

}