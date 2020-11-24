using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_keyboard_controller : MonoBehaviour
{
    public Transform bodyTransform;
    public float movementSpeed = 5f;
    public float timestep;
    public float xAngle, yAngle, zAngle;
    Vector3 bodyPosition;
    Vector3 bodyVelocity;


    
    // Start is called before the first frame update
    void Start()
    {
        bodyPosition = bodyTransform.position;
        bodyVelocity = Vector3.zero;

    }

    // Update is called once per frame
    void Update()
    {
        MovementUpdate();
        bodyPosition = bodyTransform.position;
        bodyPosition += timestep * bodyVelocity;
    }

    void MovementUpdate()
    {
        // body movement forward and backward
        if (Input.GetKey("w"))
        {
            bodyTransform.Translate(0f, 0f, movementSpeed * Time.deltaTime);
		} 
        else if (Input.GetKey("s"))
        {
            bodyTransform.Translate(0f, 0f, -movementSpeed * Time.deltaTime);
        }

        // body rotation TODO: seperate method??? probably 
	}

}
