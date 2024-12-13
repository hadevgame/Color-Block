using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TetroBlock : MonoBehaviour
{
    InputSystem controls;
    private float previousTime;
    public float fallTime = 0.8f;
    public static int height = 21;
    public static int width = 10;
    public Vector3 rotationPoint;
    private UIManager gamemanager;
   
    private static Transform[,] grid = new Transform[width,height];
    
    

    private void Awake()
    {
        controls = new InputSystem();
        controls.Enable();

        controls.grid.MoveLeft.performed += ctx => MoveLeft();
        controls.grid.MoveRight.performed += ctx => MoveRight();
        controls.grid.Down.performed += ctx => MoveDown();
        controls.grid.Rotate.performed += ctx => Rotate();
    }
    private void Start()
    {
        gamemanager = UIManager.instance;
        
    }
    /*void Update()
    {
        if(Time.timeScale != 0) 
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
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
                if (!ValidMove())
                {
                    transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90);
                }
            }

            if (Time.time - previousTime > (Input.GetKey(KeyCode.DownArrow) ? fallTime / 10 : fallTime))
            {
                transform.position += new Vector3(0, -1, 0);
                if (!ValidMove())
                {
                    transform.position -= new Vector3(0, -1, 0);
                    AddToGrid();
                    CheckLines();
                    CheckGameOver();
                    this.enabled = false;
                    FindObjectOfType<SpawnBlock>().Spawn();
                }
                previousTime = Time.time;
            }
            
        }
    }*/

    void Update()
    {
        
        if (Time.timeScale != 0)
        {
            if (Time.time - previousTime > (Input.GetKey(KeyCode.DownArrow)|| (Input.GetKey(KeyCode.S)) ? fallTime / 10 : fallTime))
            {
                transform.position += new Vector3(0, -1, 0);
                if (!ValidMove())
                {
                    transform.position -= new Vector3(0, -1, 0);
                    AddToGrid();
                    CheckLines();
                    CheckGameOver();
                    this.enabled = false;
                    FindObjectOfType<SpawnBlock>().Spawn();
                }
                previousTime = Time.time;
                
            }
            
        }
    }
    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
    public void MoveLeft()
    {
        transform.position += new Vector3(-1, 0, 0);
        if (!ValidMove())
        {
            transform.position -= new Vector3(-1, 0, 0);
        }
    }

    public void MoveRight()
    {
        transform.position += new Vector3(1, 0, 0);
        if (!ValidMove())
        {
            transform.position -= new Vector3(1, 0, 0);
        }
    }

    public void Rotate()
    {
        transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
        if (!ValidMove())
        {
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90);
        }
    }

    public void MoveDown()
    {
            transform.position += new Vector3(0, -1, 0);
           
            if (!ValidMove())
            {
                transform.position -= new Vector3(0, -1, 0);
                AddToGrid();
                CheckLines();
                CheckGameOver();
                this.enabled = false;
                FindObjectOfType<SpawnBlock>().Spawn();
            }
            previousTime = Time.time;
        
    }

    void CheckGameOver()
    {
        for (int i = 0; i < width; i++)
        {
            if (grid[i, height -1] != null && grid[i,height-2] !=null )
            {
                gamemanager.DisplayGameOver();
                ResetGrid();
                controls.Disable();
            }
        }
    }

    void ResetGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                grid[x, y] = null; 
            }
        }
    }

    void CheckLines() 
    {
        for(int i = height-2;i>=0; i--) 
        {
            if (HasLine(i)) 
            {
                DeleteLine(i);
                RowDown(i);
                gamemanager.UpdateScore();
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
        for(int z = i; z < height-1; z++) 
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

            if (roundedX < 0 || roundedX >= width  || roundedY < 0 || roundedY >= height-1)
            {
                return false;
            }

            if (grid[roundedX, roundedY] != null)
                return false;
        }
        return true;
    }
}
