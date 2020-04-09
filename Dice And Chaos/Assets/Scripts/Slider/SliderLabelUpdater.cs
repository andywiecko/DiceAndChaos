using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SliderLabelUpdater : MonoBehaviour
{

    private Slider slider;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = slider.value.ToString("0.0");
    }
}
