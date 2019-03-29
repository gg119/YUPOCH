using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MusicVolume : MonoBehaviour {
    
    private Slider slider;
    public AudioMixer mixer;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    //changes volume to slider value
    public void VolumeChange (string volParam) {
        mixer.SetFloat(volParam, slider.value);
    }
}