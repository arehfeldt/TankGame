using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTank : MonoBehaviour
{
    public GameObject parent;
    public GameObject turret;
    public GameObject body;
    public GameObject gameCamera;

    private Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        RotateObject(body, KeyCode.A, KeyCode.D, 2f);
        RotateObject(turret, KeyCode.LeftArrow, KeyCode.RightArrow, 2f);
        RotateObject(gameCamera, KeyCode.Q, KeyCode.E, 2f);
        Move();
        FireShell();
    }

    private void RotateObject(GameObject ourObject, KeyCode leftCode, KeyCode rightCode, float amount)
    {
        if (Input.GetKey(leftCode))
        {
            Debug.Log("Rotating Some Object Left");
            var rotationVector = ourObject.transform.rotation.eulerAngles;
            rotationVector.y = rotationVector.y - amount;
            ourObject.transform.rotation = Quaternion.Euler(rotationVector);
        }
        else if (Input.GetKey(rightCode))
        {
            Debug.Log("Rotating Some Object Right");
            var rotationVector = ourObject.transform.rotation.eulerAngles;
            rotationVector.y = rotationVector.y + amount;
            ourObject.transform.rotation = Quaternion.Euler(rotationVector);
        }
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("Moving Forward");
            Vector3 forwardVector = body.transform.rotation * Vector3.forward * 5;
            rigidBody.velocity = forwardVector;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("Moving Backward");
            Vector3 forwardVector = body.transform.rotation * Vector3.forward * 5;
            rigidBody.velocity = -forwardVector;
        }
    }

    private void FireShell()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Fired Shell");
        }
    }
}