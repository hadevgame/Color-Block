using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New block", menuName ="Block")]
public class Block : ScriptableObject
{
    public int column;
    public int row;

    public Sprite image;
}
