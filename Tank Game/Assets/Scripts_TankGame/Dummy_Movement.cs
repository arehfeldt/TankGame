using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy_Movement : MonoBehaviour
{
    public GameObject dummy;
    public float moveSpeed = 5f;
    Vector3 dummyPosition;
    Vector3 dummyVelocity;
    int direction;  // 0 = forward, 1 = right, 2 = backward, 3 = left

    // Start is called before the first frame update
    void Start()
    {
        dummy.transform.position = new Vector3(-20, 0, -20);
        dummyPosition = dummy.transform.position;
        dummyVelocity = Vector3.zero;
        direction = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // position / movement update
        switch (direction)
        {
            case 0:
                dummy.transform.Translate(0f, 0f, moveSpeed * Time.deltaTime);
                break;
            case 1:
                dummy.transform.Translate(moveSpeed * Time.deltaTime, 0f, 0f);
                break;
            case 2:
                dummy.transform.Translate(0f, 0f, -moveSpeed * Time.deltaTime);
                break;
            case 3:
                dummy.transform.Translate(-moveSpeed * Time.deltaTime, 0f, 0f);
                break;
            default:
                break;
        }

        dummyPosition = dummy.transform.position;

        // direction update
        switch (direction)
        {
            case 0:
                if (dummyPosition.z > 20f)
                {
                    direction = 1;
				}
                break;
            case 1:
                if (dummyPosition.x > 20f)
                {
                    direction = 2;
                }
                break;
            case 2:
                if (dummyPosition.z < -20f)
                {
                    direction = 3;
                }
                break;
            case 3:
                if (dummyPosition.x < -20f)
                {
                    direction = 0;
                }
                break;
            default:
                break;
		}

    }
}
