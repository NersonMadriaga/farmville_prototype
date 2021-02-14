using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Testing : MonoBehaviour
{
    [SerializeField] int columns, rows;
    [SerializeField] float cellSize, xOrigin, yOrigin;

    // [SerializeField] private HeatMapVisual heatMapVisual;
    [SerializeField] private HeatMapBoolVisual heatMapBoolVisual;
    private GridTerrain<HeatMapGridObject> grid;
    public void Start()
    {
        grid = new GridTerrain<HeatMapGridObject>(columns, rows, cellSize, new Vector3(xOrigin,yOrigin), (GridTerrain<HeatMapGridObject> g, int x, int y)=> new HeatMapGridObject(g,x,y));

        //heatMapVisual.SetGrid(grid);
        //heatMapBoolVisual.SetGrid(grid);
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 position = UtilsClass.GetMouseWorldPosition();
            //grid.AddValue(position, 50, 5,15);
            //grid.SetValue(position, true);
            HeatMapGridObject heatMapGridObject = grid.GetGridObject(position);

            if(heatMapGridObject != null)
            {
                heatMapGridObject.AddValue(5);
            }
        }
    }
}

public class HeatMapGridObject
{
    private const int MIN = 0, MAX = 100;
    public int value;

    private GridTerrain<HeatMapGridObject> grid;
    private int x, y;

    public HeatMapGridObject(GridTerrain<HeatMapGridObject> grid, int x, int y)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
    }
    public void AddValue(int addValue)
    {
        value += addValue;
        Mathf.Clamp(value, MIN, MAX);
        grid.TriggerGridObjectChanged(x, y);
    }

    public float GetValueNormalized()
    {
        return (float)value / MAX;
    }

    public override string ToString()
    {
        return value.ToString();
    }
}