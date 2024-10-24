using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnM2 : MonoBehaviour
{
    public GameObject[] blocks;
    private GameObject block;


    void Start()
    {
        Spawn();

    }

    public void Spawn()
    {
        block =Instantiate(blocks[Random.RandomRange(0, blocks.Length)], transform.position, Quaternion.identity);
        //block.transform.SetParent(this.transform);
    }
}
