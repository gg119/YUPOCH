using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCar : MonoBehaviour {

    void OnTriggerEnter(Collider col){
        Destroy(col.gameObject);
	}
}
