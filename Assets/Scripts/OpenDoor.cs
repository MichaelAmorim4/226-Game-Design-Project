using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : Interactable
{

    public Sprite sprite;
    public Item required;   // Item to put in the inventory if picked up

    // When the player interacts with the item
    public override void Interact()
    {
        base.Interact();

        OpenItem();
    }

    // Pick up the item
    void OpenItem()
    {
        List<Item> items = InventoryUI.GetItems();

        for (int i = 0; i < 20; i++)
        {

            if (items[i] == required)
            {

                Destroy(GetComponent<BoxCollider2D>());

                SpriteRenderer spriteR = GetComponent<SpriteRenderer>();
                spriteR.sprite = sprite;

                InventoryUI.RemoveItem(i);

                Destroy(GetComponent<OpenChest>());
            }

        }

    }

}
