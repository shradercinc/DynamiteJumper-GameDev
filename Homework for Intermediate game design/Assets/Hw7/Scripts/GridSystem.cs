using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GridSystem : MonoBehaviour
{
    public List<MyGridCell> gridCellList = new List<MyGridCell>();

    public int rows = 5;
    public int collumns = 5;
    public float cellSize = 1.0f;
    public circleBud buddy;
    public int spawncount = 5;

    public float pauseTime = 1.0f;
    public float buddySpeed = 1.0f;

    System.Random random;

    private void Awake()
    {
    }

    private void Start()
    {
        drawGrid();
        DateTime epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        random = new System.Random((int)(DateTime.Now - epochStart).TotalSeconds);

        for (int i = 0; i < spawncount; i++)
        {
            Instantiate(buddy, GetRandomLocation(), Quaternion.identity);
        }
    }

    void drawGrid()
    {
        float startx = ((-collumns / 2.0f) * cellSize) + (cellSize / 2.0f); 
        float starty = ((-rows / 2.0f) * cellSize) + (cellSize / 2.0f);

        for (int i = 0; i < rows; i++)
        {
            Debug.Log($"hey this is number #{i}");

            for (int j = 0; j < collumns; j++)
            {
                gridCellList.Add
                    (
                    new MyGridCell(startx + (j * cellSize),  starty + (i * cellSize))
                    );
            }
        }
    }
    public Vector2 GetRandomLocation()
    {

        return gridCellList[random.Next(gridCellList.Count)].location;
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < gridCellList.Count; i++)
        {
            Gizmos.DrawWireCube(gridCellList[i].location, Vector2.one * cellSize);
        }
    }
}


[System.Serializable]
public class MyGridCell
{
    public Vector2 location;


    public MyGridCell()
    {

    }
    public MyGridCell(Vector2 v)
    {
        location = new Vector2(v.x, v.y);
    }

    public MyGridCell(float x, float y)
    {
        location = new Vector2(x, y);
    }
}
