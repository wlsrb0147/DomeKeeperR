using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class S_WallGenerator : MonoBehaviour
{
    [SerializeField] Tilemap tileMap;
    [SerializeField] Tile wallTile;
    [SerializeField] Vector2Int mapSize;
    // Start is called before the first frame update
    void Start()
    {
        FillWallTile();
    }

    // Update is called once per frame
    void Update()
    {
    }
    void FillWallTile()
    {
        int count = 0;

        for (int j = mapSize.y / 2 - 1; j > -mapSize.y; j--)
        {
            for (int i = mapSize.x / 2 + 1; i < mapSize.x / 2 + 4; i++)
            {
                tileMap.SetTile(new Vector3Int(i, j - 1, 0), wallTile);
                tileMap.SetTile(new Vector3Int(-i, j - 1, 0), wallTile);
            }
            for (int i = count; i < mapSize.x / 2; i++)
            {
                tileMap.SetTile(new Vector3Int(i + 1, j, 0), wallTile);
                tileMap.SetTile(new Vector3Int(-i - 1, j, 0), wallTile);
            }

            count++;
        }
    }
}