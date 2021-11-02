using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSystem : MonoBehaviour
{

    public enum SeedType { RANDOM, CUSTOM }
    [Header("random related stuff")]
    public SeedType seedType = SeedType.RANDOM;
    public int seed = 0;
    System.Random random;
    [Space]
    public bool animatedPath;
    public List<MyGridCell> gridCellList = new List<MyGridCell>();
    public int pathLength = 10;
    public float cellSize = 1.0f;

    public Transform startLocation;


    // Start is called before the first frame update
    void Start()
    {

    }

    void SetSeed()
    {
        if (seedType == SeedType.RANDOM)
        {
            random = new System.Random();
        }
        else if (seedType == SeedType.CUSTOM)
        {
            random = new System.Random(seed);
        }
    }

    void CreatePath() 
    {
        gridCellList.Clear();
        Vector2 currentPosition = startLocation.transform.position;
        gridCellList.Add(new MyGridCell(currentPosition));

        for (int i = 0; i < pathLength; i++)
        {
            int n = random.Next(100);

            if (n.IsBetween(0, 49))
            {
                currentPosition = new Vector2(currentPosition.x + cellSize, currentPosition.y);
            }
            else
            {
                currentPosition = new Vector2(currentPosition.x, currentPosition.y + cellSize);
            }
            gridCellList.Add(new MyGridCell(currentPosition));
        }
    }

    IEnumerator CreatePathRoutine()
    {
        gridCellList.Clear();
        Vector2 currentPosition = startLocation.transform.position;
        gridCellList.Add(new MyGridCell(currentPosition));

        for (int i = 0; i < pathLength; i++)
        {
            int n = random.Next(100);

            if (n.IsBetween(0, 49))
            {
                currentPosition = new Vector2(currentPosition.x + cellSize, currentPosition.y);
            }
            else
            {
                currentPosition = new Vector2(currentPosition.x, currentPosition.y + cellSize);
            }
            gridCellList.Add(new MyGridCell(currentPosition));
        }
        yield return null;
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < gridCellList.Count; i++)
        {
            Gizmos.color = Color.white;
            Gizmos.DrawWireCube(gridCellList[i].location, Vector2.one * cellSize);
            Gizmos.color = new Color(0.5f, 0.5f, 0.5f);
            Gizmos.DrawCube(gridCellList[i].location, Vector2.one * cellSize);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetSeed();
            if (animatedPath)
            {
                StartCoroutine(CreatePathRoutine());
            }
        }
    }
}
