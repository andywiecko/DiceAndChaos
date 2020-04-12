using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceAndChaos
{

    public class ArrowViewer : MonoBehaviour
    {

        public GameObject velocityArrowAsset;
        public GameObject angularVelocityArrowAsset;

        private GameObject velocityArrow = null;
        private GameObject angularVelocityArrow = null;

        private void Start()
        {
            velocityArrow = Instantiate(velocityArrowAsset, transform);
            angularVelocityArrow = Instantiate(angularVelocityArrowAsset, transform);
            Reset();
        }

        public void SetVelocityArrow(Vector3 velocity)
        {
            if (velocityArrow != null)
            {
                velocityArrow.SetActive(true);
                velocityArrow.transform.rotation = Quaternion.LookRotation(velocity);
                velocityArrow.transform.localScale = new Vector3(1, 1, 0.334f * velocity.magnitude);
            }
        }

        public void SetAngularVelocityArrow(Vector3 velocity)
        {
            if (velocityArrow != null)
            {
                angularVelocityArrow.SetActive(true);
                angularVelocityArrow.transform.rotation = Quaternion.LookRotation(velocity);
                angularVelocityArrow.transform.localScale = new Vector3(1, 1, 0.334f * velocity.magnitude);
            }
        }

        public void SetArrowsActive(bool value = true)
        {
            velocityArrow.SetActive(value);
            angularVelocityArrow.SetActive(value);
        }

        public void Reset()
        {
            SetArrowsActive(false);
        }

    }

}