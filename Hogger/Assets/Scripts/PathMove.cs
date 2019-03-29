using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMove : MonoBehaviour {

    //public Transform[] points;
    private float speed = 0.8f;
    private Transform target;
    public int place;
	public string cubeName;
    private Vector3 originalPos;

    public bool reset;
    private bool pauseMove;
    
    private float startTime;

    private GameObject loadScreen;

    // Use this for initialization
    void Start () {
        originalPos = gameObject.transform.position;
		GameObject temp = GameObject.Find(cubeName + place);
        if(temp != null)
        {
            target = temp.transform;
            transform.LookAt(target.position);
        }

        reset = false;
        pauseMove = false;

        startTime = Time.time;

        loadScreen = GameObject.Find("Loadscreen");

        Physics.IgnoreLayerCollision(9, 9, true);
    }

    public void pauseCar()
    {
        pauseMove = true;
        startTime = Time.time;
    }
	
	// moves car to next marker in the sequence
    // markers need to start with given cubeName, followed by their position in the sequence (starting at 0)
	void Update () {

        if(reset)
        {
            place = 0;
            GameObject temp = GameObject.Find(cubeName + place);
            if (temp != null)
            {
                target = temp.transform;
                transform.LookAt(target.position);
            }

            reset = false;
        }

        if (pauseMove)
        {
            if ((Time.time - startTime) > 0.5f)
            {
                pauseMove = false;
            }
        }
        else if (target != null)
        {
            float dist = Vector3.Distance(target.position, transform.position);
            if (dist > 0.1f)
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target.position, step);

                if(dist > 5f)
                    transform.LookAt(target.position);
            }
            else
            {
                place++;
				GameObject temp = GameObject.Find(cubeName + place);
                if (temp != null)
                {
                    target = temp.transform;
                    transform.LookAt(target.position);
                }
            }
        }
    }
}
