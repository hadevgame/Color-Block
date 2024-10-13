using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockDisplay : MonoBehaviour
{
    public Block block;
    public Image imageblock;
   

    void Start()
    {
        
        imageblock.sprite = block.image;
        imageblock.SetNativeSize();
    }

    
}
