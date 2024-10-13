using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetroBlock : MonoBehaviour
{
    private float previousTime;
    public float fallTime = 0.8f;
    public static int height = 20;
    public static int width = 10;
    public Vector3 rotationPoint;

    private static Transform[,] grid = new Transform[width,height];
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            transform.position += new Vector3(-1, 0, 0);
            if (!ValidMove()) 
            {
                transform.position -= new Vector3(-1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
            if (!ValidMove())
            {
                transform.position -= new Vector3(1, 0, 0);
            }
        }else if (Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
            if (!ValidMove())
            {
                transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90);
            }
        }

        if(Time.time -previousTime> (Input.GetKey(KeyCode.DownArrow) ?fallTime/10 : fallTime))
        {
            transform.position += new Vector3(0, -1, 0);
            if (!ValidMove())
            {
                transform.position -= new Vector3(0, -1, 0);
                AddToGrid();
                CheckLines();
                this.enabled = false;
                FindObjectOfType<SpawnBlock>().Spawn();
            }
            previousTime = Time.time;
        }
    }

    void CheckLines() 
    {
        for(int i = height-1;i>=0; i--) 
        {
            if (HasLine(i)) 
            {
                DeleteLine(i);
                RowDown(i);
            }
        }
    }

    bool HasLine(int i) 
    {
        for(int j = 0; j < width; j++) 
        {
            if (grid[j,i]==null)
                return false;
        }
        return true;
    }

    void DeleteLine(int i) 
    {
        for(int j=0; j < width; j++) 
        {
            Destroy(grid[j,i].gameObject);
            grid[j, i] = null;
        }
    }

    void RowDown(int i) 
    {
        for(int z = i; z < height; z++) 
        {
            for(int j=0;j<width;j++) 
            {
                if (grid[j, z] != null) 
                {
                    grid[j,z-1] = grid[j,z];
                    grid[j,z] = null;
                    grid[j,z-1].transform.position -= new Vector3(0,1,0);
                }
            }
        }
    }
    private void AddToGrid()
    {
        foreach(Transform child in transform) 
        {
            int roundedX = Mathf.RoundToInt(child.transform.position.x);
            int roundedY = Mathf.RoundToInt(child.transform.position.y);

            grid[roundedX, roundedY] = child;       
        }
    }
    bool ValidMove() 
    {
        foreach(Transform child in transform) 
        {
            int roundedX = Mathf.RoundToInt(child.transform.position.x);
            int roundedY = Mathf.RoundToInt(child.transform.position.y);

            if (roundedX < 0 || roundedX >= width  || roundedY < 0 || roundedY >= height)
            {
                return false;
            }

            if (grid[roundedX, roundedY] != null)
                return false;
        }
        return true;
    }
}
