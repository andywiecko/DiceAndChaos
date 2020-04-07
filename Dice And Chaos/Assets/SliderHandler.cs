using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DiceAndChaos
{

    public class SliderHandler : MonoBehaviour
    {
        // rotation
        public Slider rotXSlider;
        public Slider rotYSlider;
        public Slider rotZSlider;

        // velocity
        public Slider velXSlider;
        public Slider velYSlider;
        public Slider velZSlider;

        public GameController gameController;
        public float value;

        public void Rotate()
        {
            float x = rotXSlider.value;
            float y = rotYSlider.value;
            float z = rotZSlider.value;
            gameController.Rotate(x, y, z);
        }

        public void SetVelocity()
        {
            float x = velXSlider.value;
            float y = velYSlider.value;
            float z = velZSlider.value;
            //gameController.SetVelocity(x, y, z);
        }


    }

}
