using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_keyboard_controller : MonoBehaviour
{
    public Transform bodyTransform;
    public float movementSpeed = 5f;
    public float timestep = 1;
    public float turnSpeed = 1;
    Vector3 bodyPosition;
    Vector3 bodyVelocity;

    bool moving;
    bool turning;

    
    // Start is called before the first frame update
    void Start()
    {
        bodyPosition = bodyTransform.position;
        bodyVelocity = Vector3.zero;

    }

    // Update is called once per frame
    void Update()
    {
        moving = false;
        turning = false;
        MovementUpdate();
        RotationUpdate();
        bodyPosition = bodyTransform.position;
        bodyPosition += timestep * bodyVelocity;
    }

    void MovementUpdate()
    {
        // body movement forward and backward
        if (Input.GetKey("w"))
        {
            bodyTransform.Translate(0f, 0f, movementSpeed * Time.deltaTime);
            moving = true;
		} 
        else if (Input.GetKey("s"))
        {
            bodyTransform.Translate(0f, 0f, -movementSpeed * Time.deltaTime);
            moving = true;
        }

	}

    void RotationUpdate()
    {
        if (Input.GetKey("a") && !moving)
        {
            bodyTransform.Rotate(0, -turnSpeed, 0);
            turning = true;
		} 
        else if (Input.GetKey("d") && !moving)
        {
            bodyTransform.Rotate(0, turnSpeed, 0);
            turning = true;
        }
	}

}
