using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flag : MonoBehaviour {

    public Transform player;
    public GameObject panel;
    public Text text;
	public ParticleSystem pSystem;
    private Text scoreText;

    private bool scored = false;

	// Use this for initialization
	void Start () {
		pSystem.Stop ();
        scoreText = GameObject.Find("Score Text").GetComponent<Text>();
    }
	
	// Updates score and plays particles when player gets near
	void Update () {
        float dist = Vector3.Distance(player.position, transform.position);
        if((dist < 0.15f) && !scored)
        {
            pSystem.Play();
            Player.score += 100;
            scored = true;
            scoreText.text = Player.score.ToString();

        }
	}
}
