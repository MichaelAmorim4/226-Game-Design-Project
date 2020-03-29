using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler {

    [SerializeField] private Canvas canvas;
    [SerializeField] private InventorySlot inventorySlot;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private static Item currentItemData;

    private Vector2 initial;
    private Vector2 current;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.5f;
        initial = rectTransform.anchoredPosition;
        currentItemData = inventorySlot.GetItem();
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        current = rectTransform.anchoredPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        if (current == rectTransform.anchoredPosition)
        {

            rectTransform.anchoredPosition = initial;

        } else
        {

            inventorySlot.ClearSlot();
            rectTransform.anchoredPosition = initial;   

        }
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("On Drop");
    }

    public static Item GetCurrentItem()
    {
        return currentItemData;
    }
}