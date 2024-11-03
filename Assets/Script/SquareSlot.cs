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
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition + new Vector2(1,132);
            
        }
        
    }
    /*public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");

        if (eventData.pointerDrag != null)
        {
            RectTransform dragRectTransform = eventData.pointerDrag.GetComponent<RectTransform>();
            //RectTransform dropRectTransform = GetComponent<RectTransform>();

            //dragRectTransform.anchoredPosition = dropRectTransform.anchoredPosition;
            foreach (Transform child in dragRectTransform)
            {
                RectTransform childRectTransform = child.GetComponent<RectTransform>();
                if (childRectTransform != null)
                {
                    //Debug.Log("Child position: " + childRectTransform.anchoredPosition);
                    child.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                }
            }
        }
    }*/
}
