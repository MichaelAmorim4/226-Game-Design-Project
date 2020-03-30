using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : Interactable
{
    
    public Item required;   // Item to put in the inventory if picked up
    public Item add;

    // When the player interacts with the item
    public override void Interact()
    {
        base.Interact();

        OpenItem();
    }

    // Pick up the item
    void OpenItem()
    {
        InventorySlot[] slots = InventoryUI.GetInventorySlots();

        for (int i = 0; i < 20; i++)
        {

            if (slots[i].item == required)
            {
                Destroy(gameObject);
                slots[i].ClearSlot();
                Inventory.instance.Add(add);
            }

        }

    }

}
