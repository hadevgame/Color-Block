using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlock : MonoBehaviour
{
    public GameObject[] blocks;
    private GameObject spawnedPrefab;
   
    void Start()
    {
        Spawn();
       
    }
    
    public void Spawn() 
    {
        spawnedPrefab = Instantiate(blocks[Random.RandomRange(0, blocks.Length)], transform.position, Quaternion.identity);
    }
   
}
