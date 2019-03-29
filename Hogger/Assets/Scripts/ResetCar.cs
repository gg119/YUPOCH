using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCar : MonoBehaviour {

    public Transform resetPoint;
	

    /* When the Cars collide with the Destruction plane 
    then the Cars will be sent back to their original position. */
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.layer == 10)
        {
            gameObject.transform.position = resetPoint.position;

            this.gameObject.GetComponent<PathMove>().reset = true;
        }
        if(col.gameObject.layer == 9)
        {
            var heading = col.gameObject.transform.position - transform.position;
            float dot = Vector3.Dot(heading, transform.forward);

            if(dot > .5f)
            {
                this.gameObject.GetComponent<PathMove>().pauseCar();
            }
        }
    }
}
