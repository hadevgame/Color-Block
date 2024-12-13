using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TetroBlockM2 : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    [HideInInspector] public Transform parentAfterDrag;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup= GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        /*parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();*/
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        //rectTransform.anchoredPosition += eventData.delta;
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        //transform.SetParent(parentAfterDrag);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }
}
