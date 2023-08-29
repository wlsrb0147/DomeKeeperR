using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Tilemaps;

public class S_MapGenerator : MonoBehaviour
{

    Vector3Int cellPosition;
    public GameObject redjam;
    public GameObject bluejam;
    public GameObject greenjam;

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
        FillTile();
    }

    void FillTile()
    {
        int count = 0;

        for (int j = mapSize.y / 2 - 1; j > -mapSize.y; j--)
        {
            tileMap.SetTile(new Vector3Int(0, j, 0), GroundTile);

            for (int i = 1; i <= mapSize.x / 2; i++)
            {
                int rnd = Random.Range(0, 100);

                if (rnd >= 0 && rnd < 18 && j > -mapSize.y+1)
                {
                    CreatGround(j, i);
                    CreatGround(j, -i);
                }

                if (rnd >= 19 && rnd < 60)
                {
                    tileMap.SetTile(new Vector3Int(i, j, 0), GroundTile2);
                    tileMap.SetTile(new Vector3Int(-i, j, 0), GroundTile2);
                }
                else
                {
                    tileMap.SetTile(new Vector3Int(i, j, 0), GroundTile);
                    tileMap.SetTile(new Vector3Int(-i, j, 0), GroundTile);
                }

                if (i > count)
                {
                    break;
                }
            }
            count++;
        }
    }

    void CreatGround(int j, int i)
    {
        int rnd = Random.Range(0, 19);

        if (rnd >= 0 && rnd < 6)
        {
            var mine = Instantiate(redjam, tileMap.transform);
            mine.transform.position = new Vector3(i + mineralXoffeset, j - mineralYoffeset, 0);
            tileMap.SetTile(new Vector3Int(i, j, 0), mineralTile);
            tileMap.SetTile(new Vector3Int(-i, j, 0), mineralTile);
        }
        else if (rnd >= 6 && rnd < 12)
        {
            var mine = Instantiate(bluejam, tileMap.transform);
            mine.transform.position = new Vector3(i + mineralXoffeset, j - mineralYoffeset, 0);
            tileMap.SetTile(new Vector3Int(i, j, 0), mineralTile);
            tileMap.SetTile(new Vector3Int(-i, j, 0), mineralTile);
        }
        else if (rnd >= 12 && rnd < 18)
        {
            var mine = Instantiate(greenjam, tileMap.transform);
            mine.transform.position = new Vector3(i + mineralXoffeset, j - mineralYoffeset, 0);
            tileMap.SetTile(new Vector3Int(i, j, 0), mineralTile);
            tileMap.SetTile(new Vector3Int(-i, j, 0), mineralTile);
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

                        for (int i = 0; i < 9; i++)
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