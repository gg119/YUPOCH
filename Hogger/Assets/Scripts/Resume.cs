using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour {

    GameObject player;
    AudioSource mainAudio;
    private void Awake()
    {
       player = GameObject.Find("NPC_neutral");
       AudioSource[] audio = player.GetComponents<AudioSource>();
       mainAudio = audio[0];

}

    //exits pause menu, allows movement
    public void ResumeGame(Canvas menu)
    {
        menu.gameObject.SetActive(false);
        Player.state = (int)Player.popupStates.none;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        mainAudio.Play();
    }
}
