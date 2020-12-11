using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerLocationOnStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectsWithTag("Player")[0].transform.position = gameObject.transform.position;
    }
}
