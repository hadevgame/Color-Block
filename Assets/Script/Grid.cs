using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public GameObject cellPrefab; // Prefab của ô vuông
    public int gridSize = 10;
    void Start()
    {
        CreateGrid();
    }

    void CreateGrid()
    {
        for (int row = 0; row < gridSize; row++)
        {
            for (int col = 0; col < gridSize; col++)
            {
                // Tạo một ô vuông mới
                GameObject cell = Instantiate(cellPrefab, transform);

                cell.transform.localPosition = new Vector3(col, row, 0);
            }
        }
    }
}
