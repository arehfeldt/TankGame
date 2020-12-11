using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTank : MonoBehaviour
{
    public GameObject parent;
    public GameObject turret;
    public GameObject body;

    private Rigidbody rigidBody;
    private TankHealth health;
    private PlayerStats stats;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        health = GetComponent<TankHealth>();
        stats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        if (!health.IsDead())
        {
            RotateObject(body, KeyCode.A, KeyCode.D, stats.rotateChassis);
            RotateObject(turret, KeyCode.A, KeyCode.D, stats.rotateChassis);
            RotateObject(turret, KeyCode.LeftArrow, KeyCode.RightArrow, stats.rotateTurret);
            Move();
        }
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
            Vector3 forwardVector = body.transform.rotation * Vector3.forward * stats.movementSpeed;
            rigidBody.velocity = forwardVector;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("Moving Backward");
            Vector3 forwardVector = body.transform.rotation * Vector3.forward * stats.movementSpeed;
            rigidBody.velocity = -forwardVector;
        }
    }

    public void Reset()
    {
        health.Reset();
        stats.Reset();
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            var child = gameObject.transform.GetChild(i).gameObject;
            if (child != null)
                child.SetActive(true);
        }
    }

}