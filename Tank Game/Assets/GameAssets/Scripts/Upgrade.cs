using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public string UpgradeType;
    public GameObject Defender;

    void Start()
    {
        GameObject defender = Instantiate(Defender);
        defender.transform.position = gameObject.transform.position + new Vector3(0, defender.transform.localScale.y / 2, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerStats stats = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerStats>();
            if (!stats) return;
            stats.ModifyStats(UpgradeType);
            Destroy(gameObject);
        }
    }
}
