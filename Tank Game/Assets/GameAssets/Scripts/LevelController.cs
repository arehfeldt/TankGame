using System.Collections;
using System.Collections.Generic;
using DungeonArchitect;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public Dungeon Dungeon;
    public GameObject Player;
    public GameObject parent;

    private GameObject player;
    private Dungeon dungeon;

    public void BuildDungeon()
    {
        dungeon = Instantiate(Dungeon);
        dungeon.Config.Seed = (uint)Random.Range(0, 1000000);
        dungeon.Build();
        player.transform.position = GameObject.FindGameObjectsWithTag("Respawn")[0].transform.position;
    }

    public void DestroyDungeon()
    {
        dungeon.DestroyDungeon();
    }

    public void ResetDungeon()
    {
        DestroyDungeon();
        BuildDungeon();
    }

    private void SpawnPlayer()
    {
        player = Instantiate(Player);
    }

    private void Awake()
    {
        SpawnPlayer();
        BuildDungeon();
    }
}
