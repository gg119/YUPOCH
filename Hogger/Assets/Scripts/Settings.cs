using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour {

    public GameObject pause;
    public GameObject settings;

	public void OpenSettings()
    {
        pause.SetActive(false);
        settings.SetActive(true);
    }
}
