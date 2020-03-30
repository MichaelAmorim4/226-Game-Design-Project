using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : Interactable
{
    
    public Item item;   // Item to put in the inventory if picked up

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

        for (int i = 0; i < 27; i++)
        {

            if (slots[i].item == item)
            {
                Destroy(gameObject);
            }

        }

    }

}
