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

        // angular velocity
        public Slider angVelXSlider;
        public Slider angVelYSlider;
        public Slider angVelZSlider;

        private GameController gameController;

        public void Reset()
        {
            // TODO move all these to List<Slider> sliders
            rotXSlider.SetValueWithoutNotify(0f);
            rotYSlider.SetValueWithoutNotify(0f);
            rotZSlider.SetValueWithoutNotify(0f);

            velXSlider.SetValueWithoutNotify(0f);
            velYSlider.SetValueWithoutNotify(0f);
            velZSlider.SetValueWithoutNotify(0f);

            angVelXSlider.SetValueWithoutNotify(0f);
            angVelYSlider.SetValueWithoutNotify(0f);
            angVelZSlider.SetValueWithoutNotify(0f);

            SetSliders();
        }

        private void Start()
        {
            gameController = GetComponent<GameController>();
            SetSliders();
        }

        public void SetSliders()
        {
            Rotate();
            SetVelocity();
            SetAngularVelocity();
        }

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
            gameController.SetVelocity(x, y, z);
        }

        public void SetAngularVelocity()
        {
            float x = angVelXSlider.value;
            float y = angVelYSlider.value;
            float z = angVelZSlider.value;
            gameController.SetAngularVelocity(x, y, z);

        }

    }

}
