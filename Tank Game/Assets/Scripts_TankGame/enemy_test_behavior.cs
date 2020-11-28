using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_test_behavior : MonoBehaviour
{
    public Transform enemyTransform;
    public float movementSpeed = 0.5f;
    public float jumpVelocity = 20f;
    public float timeStep = 0.5f;

    Vector3 bodyPosition;
    Vector3 bodyVelocity;
    Vector3 gravity = new Vector3(0,-9.8f,0);
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        jumpUpdate();
        bodyPosition = enemyTransform.position;
        bodyVelocity += timeStep * gravity;
        bodyPosition += timeStep * bodyVelocity;

        if (bodyPosition.y < 0.5f)
        {
            bodyPosition.y = 0.5f;
            bodyVelocity = Vector3.zero;
		}

        enemyTransform.position = bodyPosition;
    }

    void jumpUpdate()
    {
        if (bodyPosition.y == 0.5f)
        {
            bodyVelocity.y += jumpVelocity;
		}
	}
}
