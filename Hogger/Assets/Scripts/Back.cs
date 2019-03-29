using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour {

    public GameObject pause;
    public GameObject settings;

    public void CloseSettings()
    {
        pause.SetActive(true);
        settings.SetActive(false);
    }
}
