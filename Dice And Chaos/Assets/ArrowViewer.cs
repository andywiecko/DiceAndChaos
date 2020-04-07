using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceAndChaos
{

    public class ArrowViewer : MonoBehaviour
    {

        public GameObject arrowAsset;
        private GameObject arrow;

        private void Start()
        {
            arrow = Instantiate(arrowAsset, transform);
           // arrow.SetActive(false);
        }

        public void SetVelocityArrow(Vector3 velocity)
        {
            arrow.transform.rotation = Quaternion.LookRotation(velocity);
            arrow.transform.localScale = new Vector3(1,1,velocity.magnitude);
        }



    }

}