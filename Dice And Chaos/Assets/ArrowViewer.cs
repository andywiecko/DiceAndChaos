using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceAndChaos
{

    public class ArrowViewer : MonoBehaviour
    {

        public GameObject arrowAsset;
        private GameObject arrow = null;

        private void Start()
        {
            arrow = (GameObject)Instantiate(arrowAsset, transform);
            Reset();
        }

        public void SetVelocityArrow(Vector3 velocity)
        {
            if (arrow != null)
            {
                arrow.SetActive(true);
                arrow.transform.rotation = Quaternion.LookRotation(velocity);
                arrow.transform.localScale = new Vector3(1, 1, 0.334f * velocity.magnitude);
            }
        }

        public void Reset()
        {
            arrow.SetActive(false);
        }

    }

}