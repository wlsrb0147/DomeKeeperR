using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Tilemaps;

public class S_MapGenerator : MonoBehaviour
{

    public Vector3Int cellPosition;
    public GameObject mineral;

    bool[] nullTile;

    [Header("MapStatus")]
    [SerializeField] Vector2Int mapSize;
    [SerializeField] float mineralXoffeset;
    [SerializeField] float mineralYoffeset;

    [Header("Tile")]
    [SerializeField] Tilemap tileMap;
    [SerializeField] Tile mineralTile;
    [SerializeField] Tile GroundTile;
    [SerializeField] Tile GroundTile2;
    [SerializeField] Tile GroundTile3;
    [SerializeField] Tile GroundTile4;
    [SerializeField] Tile downTile;
    [SerializeField] Tile topTile;
    [SerializeField] Tile leftWallTile;
    [SerializeField] Tile rightWallTile;
    [SerializeField] Tile RdownCornerTile;
    [SerializeField] Tile LdownCornerTile;
    [SerializeField] Tile RupCornerTile;
    [SerializeField] Tile LupCornerTile;

    void Start()
    {
        tileMap = GetComponent<Tilemap>();
        FillBackground();
    }


    void FillBackground()
    {

        for (int i = -10; i < mapSize.x + 10; i++) //바깥타일은 맵 가장자리에 가도 어색하지 않게, 10만큼 여유
        {
            for (int j = -10; j < mapSize.y + 10; j++)
            {
                int rnd = Random.Range(0, 100);

                if (rnd >= 0 && rnd < 6)
                {
                    //tileMap.SetTile(new Vector3Int(i - mapSize.x / 2, j - mapSize.y / 2, 0), mineralTile);
                    var mine = Instantiate(mineral, tileMap.transform);
                    mine.transform.position = new Vector3(i - mapSize.x / 2 + mineralXoffeset, j - mapSize.y / 2 - mineralYoffeset, 0);
                    tileMap.SetTile(new Vector3Int(i - mapSize.x / 2, j - mapSize.y / 2, 0), mineralTile);

                }
                else if(rnd >=6 && rnd < 20)
                {
                    tileMap.SetTile(new Vector3Int(i - mapSize.x / 2, j - mapSize.y / 2, 0), GroundTile2);
                }
                else if (rnd >= 20 && rnd < 40)
                {
                    tileMap.SetTile(new Vector3Int(i - mapSize.x / 2, j - mapSize.y / 2, 0), GroundTile3);
                }
                else if (rnd >= 40 && rnd < 60)
                {
                    tileMap.SetTile(new Vector3Int(i - mapSize.x / 2, j - mapSize.y / 2, 0), GroundTile4);
                }
                else
                    tileMap.SetTile(new Vector3Int(i - mapSize.x / 2, j - mapSize.y / 2, 0), GroundTile);

            }
        }
    }




    void FillWall() //룸 타일과 바깥 타일이 만나는 부분 
    {
        if (tileMap.GetTile(cellPosition) == null) //현재타일이 null이면
        {
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    Vector3Int checkTilePos = new Vector3Int(cellPosition.x + x, cellPosition.y + y, 0);

                    if (x == 0 && y == 0) { continue; }

                    if (tileMap.GetTile(checkTilePos) != null)  //처음 깨진 블록 기준으로 탐색 된 주변 블록
                    {
                        nullTile = new bool[9];
                        int count = 0;

                        for(int i = 0; i < 9; i++)
                        {
                            nullTile[i] = false;
                        }

                        for (int _x = -1; _x <= 1; _x++)
                        {
                            for (int _y = -1; _y <= 1; _y++)
                            {
                                if (tileMap.GetTile(new Vector3Int(checkTilePos.x + _x, checkTilePos.y + _y, 0)) == null) //위에서 탐색된 블록 기준 주변 블록
                                {
                                    nullTile[count] = true;
                                }
                                count++;
                            }
                        }

                        if (nullTile[1] && nullTile[3])
                            tileMap.SetTile(new Vector3Int(checkTilePos.x, checkTilePos.y, 0), LdownCornerTile);
                        else if (nullTile[3] && nullTile[7])
                            tileMap.SetTile(new Vector3Int(checkTilePos.x, checkTilePos.y, 0), RdownCornerTile);
                        else if (nullTile[5] && nullTile[7])
                            tileMap.SetTile(new Vector3Int(checkTilePos.x, checkTilePos.y, 0), RupCornerTile);
                        else if (nullTile[1] && nullTile[5])
                            tileMap.SetTile(new Vector3Int(checkTilePos.x, checkTilePos.y, 0), LupCornerTile);
                        else if (!nullTile[0] && !nullTile[1] && !nullTile[2] && nullTile[7])
                            tileMap.SetTile(new Vector3Int(checkTilePos.x, checkTilePos.y, 0), rightWallTile);
                        else if (!nullTile[6] && !nullTile[7] && !nullTile[8] && nullTile[1])
                            tileMap.SetTile(new Vector3Int(checkTilePos.x, checkTilePos.y, 0), leftWallTile);
                        else if (!nullTile[3] && nullTile[5])
                            tileMap.SetTile(new Vector3Int(checkTilePos.x, checkTilePos.y, 0), topTile);
                        else if (nullTile[3] && !nullTile[5])
                            tileMap.SetTile(new Vector3Int(checkTilePos.x, checkTilePos.y, 0), downTile);
                    }

                }
            }

        }
    }


    public void MakeDot(Vector3 Pos)
    {
        cellPosition = tileMap.WorldToCell(Pos);

        tileMap.SetTile(cellPosition, null);
        FillWall();
    }
}


