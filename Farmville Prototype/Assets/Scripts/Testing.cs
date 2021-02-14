using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Testing : MonoBehaviour
{
    [SerializeField] int columns, rows;
    [SerializeField] float cellSize, xOrigin, yOrigin;

    [SerializeField] private HeatMapVisual heatMapVisual;
    private GridTerrain grid;
    public void Start()
    {
        grid = new GridTerrain(columns, rows, cellSize, new Vector3(xOrigin,yOrigin));

        heatMapVisual.SetGrid(grid);
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 position = UtilsClass.GetMouseWorldPosition();

            grid.AddValue(position, 50, 5,15);
        }
    }
}
