using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public float NextSpawnYPos = -7f;

    public GameObject Player;
    public GameObject GrayPart;
    public GameObject WhitePart;
    public GameObject WindowPart;

    public int maxWindowsPerLine = 1;
    public int minWindowsPerLine = 0;

    public int maxGraysPerLine = 2;
    public int minGraysPerLine = 1;

    public int partsCount = 6;
    public int linesCount = 4;

    //x מע -7,5 המ  7,5 ס ראדמל 3

    // Update is called once per frame
    void Update()
    {
        // -7 - (-5) == -2
        if (Player.transform.position.y - NextSpawnYPos < 10)
        {
            //NextSpawnYPos -= 10;
            var grid = GenerateGrid();
            PaintGrid(grid);
        }
    }

    private void PaintGrid(GameObject[,] grid)
    {
        var startX = -7.5f;
        var step = 3;
        var y = NextSpawnYPos;
        for (var i = 0; i<linesCount;  i++)
        {
            var x = startX;       
            for (var j=0; j<partsCount; j++)
            {
                var spawnPosX = new Vector3(x, y, 0);
                Instantiate(grid[i,j], spawnPosX, grid[i, j].transform.rotation);
                x += step;
            }
            y -= step;
        }
        NextSpawnYPos -= 12;
    }

    private GameObject[,] GenerateGrid()
    {
        var count = 4;
        var grid = new GameObject[count, partsCount];
        for (var i=0; i < count; i++)
        {
            var line = GenerateOneLine();
            for (var j = 0; j < partsCount; j++)
            {
                grid[i, j] = line[j];
            }
        }
        return grid;
    }
    private GameObject[] GenerateOneLine()
    {
        var windowsCount = GetCount(minWindowsPerLine, maxWindowsPerLine);
        var graysCount = GetCount(minGraysPerLine, maxGraysPerLine);
        var grid = new GameObject[partsCount];
        FindPositions(graysCount, grid, GrayPart);
        FindPositions(windowsCount, grid, WindowPart);
        FillOtherPositions(grid, WhitePart);
        return grid;
    }

    private int GetCount(int min, int max)
    {
        return Random.Range(min, max + 1); 
    }
    private void FindPositions(int count, GameObject[] grid, GameObject gameObject)
    {
        //  ״טחמטהםûי אכדמנטעל
        while (count > 0){
            var pos = Random.Range(0, partsCount);
            if (grid[pos] == null){
                count--;
                grid[pos] = gameObject;
            }
        }
    }
    private void FillOtherPositions(GameObject[] grid, GameObject gameObject)
    {   
        for (var i = 0; i< grid.Length; i++)
        {
            if (grid[i] == null) 
            {
                grid[i] = gameObject;
            }
        }
    }
}