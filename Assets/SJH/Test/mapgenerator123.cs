using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class mapgenerator123 : MonoBehaviour
{
    public int width, height;

    public string seed;
    public bool useRandomSeed;

    [Range(0, 100)]
    public int randomFillPercent;
    int[,] map;

    private void Start()
    {
        GenerateMap();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GenerateMap();
        }
    }
    void RandomFillMap()
    {
        if (useRandomSeed)
        {
            seed = Time.time.ToString();
        }

        System.Random pseudoRandom = new System.Random(seed.GetHashCode());

        for(int x = 0; x< width; x++)
        {
            for(int y = 0; y< height; y++) 
            {
                if(x==0 || x == width-1 || y==0 || y == height-1)
                {
                    map[x, y] = 1;
                }
                else
                {
                    map[x,y] = pseudoRandom.Next(0,100) < randomFillPercent ? 1: 0;
                }
            }
        }
    }

    void GenerateMap()
    {
        map = new int[width,height];
        RandomFillMap();
    }

    private void OnDrawGizmos()
    {
        if(map is null)
        {
            return;
        }

        for(int x = 0; x< width; x++)
        {
            for (int y = 0; y< height;y++)
            {
                Gizmos.color = map[x,y] == 1 ? Color.black : Color.white;
                Vector2 pos = new Vector2(-width / 2 + x + 0.5f, -height / 2 + y + 0.5f);
                Gizmos.DrawCube(pos, Vector2.one);
            }
        }
    }

    int GetAdjustCells(int currentX, int currentY)
    {
        int cells = 0;
        for(int i = 01; i<=1; i++)
        {
            for(int j=-1;j<=1; j++)
            {
                if(i==0 && j==0) { continue; }
                int adjX = currentX + i;
                int adjY = currentY + j;
                if (adjX < 0 || adjY < 0 || adjX >= width || adjY >= height) ++cells;
                else cells += map[adjX, adjY];
            }
        }
        return cells;
    }


}
