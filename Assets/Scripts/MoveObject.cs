using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : PortalTraveller {
    public float maxSpeed = 1;
    float speed;
    float targetSpeed;
    float smoothV;
    bool forward = true;

    void Start () {
        Debug.Log ("Press C to stop/start car");
        targetSpeed = maxSpeed;
    }

    void Update () {
        float moveDst = Time.deltaTime * speed;

        if(forward)
            transform.position += transform.forward * Time.deltaTime * speed;
        else
            transform.position -= transform.forward * Time.deltaTime * speed;

        if (Input.GetKeyDown (KeyCode.C)) {
            targetSpeed = (targetSpeed == 0) ? maxSpeed : 0;
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            forward = !forward;
        }

        speed = Mathf.SmoothDamp (speed, targetSpeed, ref smoothV, .5f);
    }
}