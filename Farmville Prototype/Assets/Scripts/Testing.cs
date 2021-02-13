using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Testing : MonoBehaviour
{
    [SerializeField] int columns, rows;
    [SerializeField] float cellSize, xOrigin, yOrigin;
    private GridTerrain grid;
    // Start is called before the first frame update
    void Start()
    {
        grid = new GridTerrain(columns,rows,cellSize,new Vector3(xOrigin,yOrigin));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            grid.SetValue(UtilsClass.GetMouseWorldPosition(),56);
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(grid.GetValue(UtilsClass.GetMouseWorldPosition()));
        }


    }
}
