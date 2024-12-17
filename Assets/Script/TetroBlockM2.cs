using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class TetroBlockM2 : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public static int height = 10;
    public static int width = 10;
    private static Transform[,] grid = new Transform[width, height];
    public Camera mainCamera; 
    public RectTransform canvasRectTransform;

    private void Start()
    {
        ResetGrid();
    }
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
        
        AddToGrid();
        
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }
    private void AddToGrid()
    {
        foreach (Transform child in transform)
        {
            /*int roundedX = Mathf.RoundToInt(child.transform.position.x);
            int roundedY = Mathf.RoundToInt(child.transform.position.y);
            grid[roundedX, roundedY] = child;*/
            Vector3 worldPosition = child.transform.position;

            Vector3 screenPosition = mainCamera.WorldToScreenPoint(worldPosition);
            
            Vector2 canvasPosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, screenPosition, mainCamera, out canvasPosition);

            int roundedX = Mathf.RoundToInt((canvasPosition.x +407)/90);
            int roundedY = Mathf.RoundToInt((canvasPosition.y +293)/90);

            grid[roundedX, roundedY] = child;

            Debug.Log("Tọa độ trong Canvas: " + canvasPosition);
            Debug.Log(roundedX);
            Debug.Log(roundedY);
        }

    }

    bool ValidMove()
    {
        foreach (Transform child in transform)
        {
            Vector3 worldPosition = child.transform.position;

            Vector3 screenPosition = mainCamera.WorldToScreenPoint(worldPosition);

            Vector2 canvasPosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, screenPosition, mainCamera, out canvasPosition);

            int roundedX = Mathf.RoundToInt((canvasPosition.x + 407) / 90);
            int roundedY = Mathf.RoundToInt((canvasPosition.y + 293) / 90);

            if (roundedX < 0 || roundedX >= width || roundedY < 0 || roundedY >= height - 1)
            {
                return false;
            }

            if (grid[roundedX, roundedY] != null)
                return false;
        }
        return true;
    }
    void ResetGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                grid[x, y] = null;
            }
        }
    }
}
