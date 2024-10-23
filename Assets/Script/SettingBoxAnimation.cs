using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingBoxAnimation : MonoBehaviour
{
    public Animator anim;

    public void PlayAnim(string name)
    {
        anim.SetTrigger(name);
    }
}
