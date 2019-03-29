using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour {

    public Transform target;

	// Use this for initialization
	void Start () {
		
	}
	
	// rotates compas to position of target
	void Update () {
        var targetPosLocal = Camera.main.transform.InverseTransformPoint(target.position);
        var targetAngle = -Mathf.Atan2(targetPosLocal.x, targetPosLocal.y) * Mathf.Rad2Deg + 40;
        transform.eulerAngles = new Vector3(0, 0, targetAngle);
    }
}
