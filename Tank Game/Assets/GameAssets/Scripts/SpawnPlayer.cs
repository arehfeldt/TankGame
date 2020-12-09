using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject objectPrefab;
    public GameObject objectClone;
    public GameObject parent;

    void SpawnObject()
    {
        objectClone = Instantiate(objectPrefab, parent.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
    }

    private void Start()
    {
        SpawnObject();
    }
}
