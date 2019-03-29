using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCrash : MonoBehaviour {
    // Position of Player
	Vector3 playerPosition;

    // Audio for when player collides with car.
    private AudioSource ouchAudio;

    // Initialization
    void Start()
    {
       AudioSource[] audio = GetComponents<AudioSource>();
       ouchAudio = audio[1];
    }

    /* When player collides with car the Player will make sound and 
    will be sent back to their original postion */
    void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.layer == 9) {
            ouchAudio.Play();
			playerPosition = new Vector3 (6.736458f, 0.347f, 16.97403f);
			this.transform.position = playerPosition;
		}
	}
}
