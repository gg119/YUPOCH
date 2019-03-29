using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Animator anim;

    public Canvas menu;
    public enum popupStates {none, flag, intro, menu, map };
    public static int state;
    public GameObject indicator;
	private float speed = 0.65f;
	private float sprint = 1.5f;
	private float walk = 0.65f;

    public static int score = 0;

    private AudioSource mainAudio;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        state = (int)popupStates.intro;

        AudioSource[] audio = GetComponents<AudioSource>();
        mainAudio = audio[0];
    }

    // controls player input, like movement, jumping, pause menu, etc
    void Update()
    {
        if (state == (int)popupStates.none)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
                {
                    transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                speed = sprint;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                speed = walk;
            }

            if (Input.GetKey("w"))
            {
                anim.SetBool("walk", true);
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
            }
            else
            {
                anim.SetBool("walk", false);
            }

            if (Input.GetKey("s"))
            {
                anim.SetBool("back", true);
                transform.Translate(Vector3.back * Time.deltaTime * speed);
            }
            else
            {
                anim.SetBool("back", false);
            }

            if (Input.GetKey("a"))
            {
                anim.SetBool("left", true);
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }
            else
            {
                anim.SetBool("left", false);
            }

            if (Input.GetKey("d"))
            {
                anim.SetBool("right", true);
                transform.Translate(Vector3.right * Time.deltaTime * speed);
            }
            else
            {
                anim.SetBool("right", false);
            }

			if (Input.GetKeyDown (KeyCode.Space)) 
			{
				Vector3 jumpTemp = new Vector3 (0, 0.3f, 0);
				this.transform.position += jumpTemp;
			}


        }

        //opens pause menu, stops movement
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (state == (int)popupStates.menu)
            {
                menu.gameObject.SetActive(false);
                state = (int)popupStates.none;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1;
                mainAudio.Play();
            }
            else if (state == (int)popupStates.none)
            {
                menu.gameObject.SetActive(true);
                state = (int)popupStates.menu;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
                mainAudio.Pause();
            }
        }

        //switches to map view and pauses movement
        if (Input.GetKeyDown("m"))
        {
            if (state == (int)popupStates.map)
            {
                Camera.main.depth = 1;
                indicator.SetActive(false);
                state = (int)popupStates.none;

            }
            else if (state == (int)popupStates.none)
            {
                Camera.main.depth = -1;
                indicator.SetActive(true);
                state = (int)popupStates.map;

            }
        }
    }
}