using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    GameObject player;

    float offset = 30f;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        gameObject.transform.rotation = Quaternion.Euler(90, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        CheckRotation();
        SetPosition();
    }

    void CheckRotation()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            Debug.Log("Rotating Some Object Left");
            var rotationVector = gameObject.transform.rotation.eulerAngles;
            rotationVector.y = rotationVector.y - 2f;
            gameObject.transform.rotation = Quaternion.Euler(rotationVector);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            Debug.Log("Rotating Some Object Right");
            var rotationVector = gameObject.transform.rotation.eulerAngles;
            rotationVector.y = rotationVector.y + 2f;
            gameObject.transform.rotation = Quaternion.Euler(rotationVector);
        }
    }

    void SetPosition()
    {
        if (!player) return;
        gameObject.transform.position = player.transform.position + new Vector3(0, offset, 0);
    }
}
