using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler {

    [SerializeField] private Canvas canvas;
    [SerializeField] private InventorySlot inventorySlot;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private static Item currentItemData;
    private static bool isDragging = false;

    private Vector2 start;
    private Vector2 initial;
    private Vector2 current;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");

        canvasGroup.alpha = 0.5f;
        initial = rectTransform.anchoredPosition;
        currentItemData = inventorySlot.GetItem();
        isDragging = true;
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
            if (inventorySlot != InventorySlot.GetCurrentSlot())
            {
                inventorySlot.ClearSlot();
            }
            rectTransform.anchoredPosition = initial;
            if (inventorySlot.slotNumber == 26)
            {
                InventoryUI.ClearCraftingSlots();
            }

        }

        isDragging = false;
        canvasGroup.blocksRaycasts = true;    

    }

    public static Item GetCurrentItem()
    {
        return currentItemData;
    }

    public static bool GetIsDragging()
    {
        return isDragging;
    }
}