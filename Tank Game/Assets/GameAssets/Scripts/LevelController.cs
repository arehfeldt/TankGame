using System.Collections;
using System.Collections.Generic;
using DungeonArchitect;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public Dungeon Dungeon;
    public GameObject Player;
    public GameObject parent;
    public Camera GameCamera;

    private GameObject player;
    private Dungeon dungeon;
    private Camera gameCamera;
    private bool gameRunning;

    public bool GameRunning()
    {
        return gameRunning;
    }

    public void BuildDungeon()
    {
        dungeon = Instantiate(Dungeon);
        dungeon.Config.Seed = (uint)Random.Range(0, 1000000);
        dungeon.Build();
    }

    public void DestroyDungeon()
    {
        dungeon.DestroyDungeon();
        Destroy(dungeon.gameObject);
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

    private void SpawnCamera()
    {
        gameCamera = Instantiate(GameCamera);
    }

    private void Awake()
    {
        gameRunning = false;
        SpawnPlayer();
        SpawnCamera();
        BuildDungeon();
        gameRunning = true;
    }

    public void ResetGame()
    {
        gameRunning = false;
        player.GetComponent<PlayerTank>().Reset();
        ResetDungeon();
        gameRunning = true;
    }
}
