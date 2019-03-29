using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour {

    public GameObject panel;
    public Text text;
    public static int introState;

    // Use this for initialization
    void Start () {
        introState = 0;
	}
	
	// displays series of intro messages on UI
	void Update () {
        if (introState == 0)
        {
            panel.SetActive(true);
            text.text = "Welcome to Hogger!";
            introState = 1;
        }
        if (Input.GetKeyDown("e") && (introState < 8))
        {
            if(introState == 1)
            {
                text.text = "Flags are spread throughout the city.";
                introState = 2;
            }
            else if (introState == 2)
            {
                text.text = "Get to them without being hit to increase your score.";
                introState = 3;
            }
            else if(introState == 3)
            {
                text.text = "Use the WASD keys to move, and the mouse to look around.";
                introState = 4;
            }
            else if (introState == 4)
            {
                text.text = "The compass in the upper left points north.";
                introState = 5;
            }
            else if (introState == 5)
            {
                text.text = "Press M to open the map.";
                introState = 6;
            }
            else if (introState == 6)
            {
                text.text = "Good Luck!";
                introState = 7;
            }
            else if (introState == 7)
            {
                Player.state = (int)Player.popupStates.none;
                introState = 9;
                panel.SetActive(false);
            }
        }
	}
}
