using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlock : MonoBehaviour
{
    public GameObject[] blocks;
    
   
    void Start()
    {
        Spawn();
       
    }
    
    public void Spawn() 
    {
       Instantiate(blocks[Random.RandomRange(0, blocks.Length)], transform.position, Quaternion.identity);
    }
   
}
