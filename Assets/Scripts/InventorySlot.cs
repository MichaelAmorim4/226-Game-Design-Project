using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/* Sits on all InventorySlots. */

public class InventorySlot : MonoBehaviour, IDropHandler
{

    public static InventorySlot inventorySlot;

    public Image icon;
    public Button removeButton;
    public int slotNumber;

    private static InventorySlot currentSlot;

    public  Item item;  // Current item in the slot

    // Add item to the slot
    public void AddItem(Item newItem)
    {
        if (newItem == null)
        {
            ClearSlot();
        }
        else
        {
            item = newItem;
            icon.sprite = item.icon;
            icon.enabled = true;
            removeButton.interactable = true;

            Inventory.instance.items[slotNumber] = item;
        }

    }

    // Clear the slot
    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;

        Inventory.instance.items[slotNumber] = null;

    }

    // If the remove button is pressed, this function will be called.
    public void RemoveItemFromInventory()
    {
        Inventory.instance.Remove(item);
    }

    // Use the item
    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }

    public Item GetItem()
    {
        return this.item;
    }



    public void OnDrop(PointerEventData eventData)
    {
        if (slotNumber != 26)
        {
            if (eventData.pointerDrag != null)
            {
                AddItem(DragDrop.GetCurrentItem());
                currentSlot = this;
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition + new Vector2(-99, 139);

            }
        }
    }

    public static InventorySlot GetCurrentSlot()
    {
        return currentSlot;
    }

}