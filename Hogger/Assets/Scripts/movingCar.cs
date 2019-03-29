using System.Collections;
using UnityEngine;

public class movingCar : MonoBehaviour {

	float speed = 1f;

	void Update()
	{
        transform.position += (transform.forward * speed * Time.deltaTime);
	
	}
}


