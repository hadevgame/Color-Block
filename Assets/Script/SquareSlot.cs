using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SquareSlot : MonoBehaviour, IDropHandler
{
    
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null) 
        {
            eventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position ;
            
        }
        /*GameObject dropped = eventData.pointerDrag;
        TetroBlockM2 block = dropped.GetComponent<TetroBlockM2>();
        block.parentAfterDrag = transform;*/
    }
    
}
