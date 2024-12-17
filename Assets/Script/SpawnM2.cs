using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnM2 : MonoBehaviour
{
    public Canvas canvas;
    public GameObject[] blocks;
    private GameObject block;
    public Camera mainCamera;
    public RectTransform canvasRectTransform;

    void Start()
    {
        Spawn();

    }

    public void Spawn()
    {
        block =Instantiate(blocks[Random.RandomRange(0, blocks.Length)], transform.position, Quaternion.identity);
        block.transform.SetParent(canvas.transform);
        TetroBlockM2 tetroBlockM2 = block.GetComponent<TetroBlockM2>();
        if (tetroBlockM2 != null) 
        {
            tetroBlockM2.mainCamera = mainCamera;
            tetroBlockM2.canvasRectTransform = canvasRectTransform;
        }
    }
}
