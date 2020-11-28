using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Tank_Shooting : MonoBehaviour
{
    // assumes original rotation aka rotation of [0, 0, 0] has turret poiting towards [0, 0, 1]
    public GameObject enemy_tank_turret;
    public float aggroRadius = 45f;
    Transform playerTransform;
    bool aggro = false;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectsWithTag("Player")[0].transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (aggro)
        {
            enemy_tank_turret.transform.LookAt(playerTransform, Vector3.up);
        }
        
        if (Vector3.Distance(playerTransform.position, enemy_tank_turret.transform.position) < aggroRadius)
        {
            aggro = true;
		}
        else
        {
            aggro = false;
		}
    }

}
