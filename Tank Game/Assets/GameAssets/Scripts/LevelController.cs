using System.Collections;
using System.Collections.Generic;
using DungeonArchitect;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public Dungeon Dungeon;
    public GameObject Player;
    public GameObject Camera;
    public GameObject parent;

    private GameObject player;
    private Dungeon dungeon;
    private DungeonArchitect.Builders.GridFlow.GridFlowDungeonConfig config;

    public void BuildDungeon()
    {
        dungeon = Instantiate(Dungeon);
        dungeon.Config.Seed = (uint)Random.Range(0, 1000000);
        dungeon.Build();
        player.transform.position = GameObject.FindGameObjectsWithTag("Respawn")[0].transform.position;

		//config = (DungeonArchitect.Builders.GridFlow.GridFlowDungeonConfig)dungeon.Config;
		//PrintNodes(config);
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
        Instantiate(Camera);
    }

    private void Awake()
    {
        SpawnPlayer();
        BuildDungeon();
    }

    private void PrintNodes(DungeonArchitect.Builders.GridFlow.GridFlowDungeonConfig c)
    {

        List<DungeonArchitect.Graphs.GraphNode> nodes = c.flowAsset.execGraph.Nodes;
        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Grant\Desktop\NodeTest.txt"))
        {
            foreach (DungeonArchitect.Graphs.GraphNode node in nodes)
            {
                file.WriteLine(node.Id);
			}
		}
	}
}
