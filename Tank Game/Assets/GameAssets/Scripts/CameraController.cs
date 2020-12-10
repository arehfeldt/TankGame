using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject gameCamera;
    GameObject player;

    float offset = 30f;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        gameCamera.tag = "MainCamera";
        gameCamera.transform.rotation = Quaternion.Euler(90, 0, 0);
        SetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        SetPosition();
        if (Input.GetKey(KeyCode.Q))
        {
            Debug.Log("Rotating Camera Object Left");
            var rotationVector = gameCamera.transform.rotation.eulerAngles;
            rotationVector.y = rotationVector.y - 2f;
            gameCamera.transform.rotation = Quaternion.Euler(rotationVector);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            Debug.Log("Rotating Camera Object Right");
            var rotationVector = gameCamera.transform.rotation.eulerAngles;
            rotationVector.y = rotationVector.y + 2f;
            gameCamera.transform.rotation = Quaternion.Euler(rotationVector);
        }
    }

    void SetPosition()
    {
        gameCamera.transform.position = player.transform.position + new Vector3(0, offset, 0);
    }
}
