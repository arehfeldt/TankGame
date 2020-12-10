using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectsWithTag("levelController")[0].GetComponent<LevelController>().ResetDungeon();
        }
    }
}
