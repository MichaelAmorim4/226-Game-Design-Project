using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    #region Singleton

    public static Inventory instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space;  // Amount of item spaces

    // Our current list of items in the inventory
    public List<Item> items = new List<Item>(20);

    // Add a new item if enough room
    public void Add(Item item)
    {

        InventorySlot[] slots = GetComponentsInChildren<InventorySlot>();

        if (item.showInInventory)
        {
            
            for (int i = 0; i < 20; i++)
            {

                if (items[i] == null)
                {
                    items[i] = item;
                    onItemChangedCallback.Invoke();
                    return;
                }

            }

            Debug.Log("Not enough room.");
                
        }
    }

    // Remove an item
    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

}
