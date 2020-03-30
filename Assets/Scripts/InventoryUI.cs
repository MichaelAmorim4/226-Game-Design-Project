using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

/* This object manages the inventory UI. */

public class InventoryUI : MonoBehaviour
{

    public GameObject inventoryUI;
    public GameObject craftingUI;
    public GameObject craftingIcons;// The entire UI
    public Transform itemsParent;   // The parent object of all the items

    Inventory inventory;    // Our current inventory
    static InventorySlot[] slots;

    void Start()
    {
        inventory = Inventory.instance;

        for(int i = 0; i < 27; i++)
        {
            inventory.items.Add(null);
        }
        slots = GetComponentsInChildren<InventorySlot>();
        inventory.onItemChangedCallback += UpdateUI;
    }

    // Check to see if we should open/close the inventory
    void Update()
    {

        if (!DragDrop.GetIsDragging())
        {
            if (Input.GetButtonDown("Inventory"))
            {
                inventoryUI.SetActive(!inventoryUI.activeSelf);
            }

            if (Input.GetButtonDown("Crafting"))
            {
                if (inventoryUI.activeSelf && craftingUI.activeSelf)
                {
                    CheckCraftingSlots();
                    craftingUI.SetActive(false);
                    craftingIcons.SetActive(false);
                }
                else
                {
                    craftingUI.SetActive(true);
                    craftingIcons.SetActive(true);
                    inventoryUI.SetActive(true);
                }

            }
        }

        UpdateUI();
    }

    // Update the inventory UI by:
    //		- Adding items
    //		- Clearing empty slots
    // This is called using a delegate on the Inventory.
    public void UpdateUI()
    {
        slots = GetComponentsInChildren<InventorySlot>();

        for (int i = 0; i < slots.Length; i++)
        {
                        
            if (inventory.items[i] != null)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

    public void CheckCraftingSlots()
    {

        slots = GetComponentsInChildren<InventorySlot>();

        for (int i = 26; i > 19; i--)
        {

            if (slots[i].item != null)
            {
                inventory.Add(slots[i].item);
                slots[i].ClearSlot();
            }
            else
            {
                slots[i].ClearSlot();
            }
        }

    }

    public static void ClearCraftingSlots()
    {
        for (int i = 25; i > 19; i--)
        {
            if (slots[i].item != DragDrop.GetCurrentItem())
            {
                slots[i].ClearSlot();
            }
        }
    }

    public static InventorySlot[] GetInventorySlots()
    {
        return slots;
    }

}