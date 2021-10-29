using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public GameObject tilePrefab;
    private List<GameObject> activeTiles = new List<GameObject>();
    private float spawnPos = 0;
    private float tileLength = 30;
    
    [SerializeField] private Transform player;
    private int startTiles = 3;

    void Start()
    {
        for (int i =0; i < startTiles; i++)
        {
            SpawnTile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.z - 30 > spawnPos - (startTiles * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
            
    }

    private void SpawnTile()
    {
        GameObject nextTile = Instantiate(tilePrefab, transform.forward * spawnPos, transform.rotation);
        activeTiles.Add(nextTile);
        spawnPos += tileLength;
    }

    private void DeleteTile()
    {
            Destroy(activeTiles[0]);
            activeTiles.RemoveAt(0);
    }
}
