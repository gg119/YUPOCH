using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

    public Transform lookAt;

    private float distance = 0.90f;
    private float currentX = 80.0f;
    private float currentY = 20.0f;

    public static float sensitivityX = 1.0f;
    public static float sensitivityY = 1.0f;

    // Use this for initialization
    void Start () {
        
	}

    // update camera to match mouse movement
    private void LateUpdate()
    {
        if (Player.state == (int)Player.popupStates.none)
        {
            Vector3 dir = new Vector3(0, 0, -distance);
            Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

            Vector3 pos = lookAt.position;
            pos.y += 0.1f;

            transform.position = pos + rotation * dir;
            transform.LookAt(pos);
        }
    }

    // gets movement of mouse
    void Update () {
        if (Player.state == (int)Player.popupStates.none)
        {
            currentX += Input.GetAxis("Mouse X") * sensitivityX;
            currentY += Input.GetAxis("Mouse Y") * sensitivityY;

            currentY = Mathf.Clamp(currentY, 10.0f, 60.0f);
        }
    }
}
