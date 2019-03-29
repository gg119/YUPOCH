using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XSensitive : MonoBehaviour {

    public Slider slider;

    //change horozontal sensitivity in main camera script
    //formula credit: https://stackoverflow.com/questions/7246622/how-to-create-a-slider-with-a-non-linear-scale
    public void XSensitiveChange()
    {
        float A = 0;
        float B = 0.81f / 8.1f;
        float C = 2.0f * Mathf.Log(9.0f / 0.9f);

        MainCamera.sensitivityX = A + B * Mathf.Exp(C * slider.value);
    }
}
