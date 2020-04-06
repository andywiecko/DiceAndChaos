using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DiceAndChaos
{

    public class SliderHandler : MonoBehaviour
    {
        public Slider sliderX;
        public Slider sliderY;
        public Slider sliderZ;


        public GameController gameController;
        public float value;

        public void Rotate()
        {
            float x = sliderX.value;
            float y = sliderY.value;
            float z = sliderZ.value;
            gameController.Rotate(x, y, z);
        }

    }

}
