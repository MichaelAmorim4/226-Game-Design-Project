using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : Interactable
{
    
    public Item required;   // Item to put in the inventory if picked up
    public Item letter1;
    public Item letter2;
    public Item letter3;
    public Item letter4;

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
                if (required.name == "_WOOD_" || required.name == "_ARMOUR_")
                {
                    Destroy(GetComponent<BoxCollider2D>());
                    Destroy(GetComponent<EdgeCollider2D>());
                    SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                    spriteRenderer.enabled = true;
                    if (required.name == "_WOOD_")
                    {
                        InventoryUI.RemoveItem(i);
                    }
                }
                else
                {
                    Destroy(gameObject);
                    InventoryUI.RemoveItem(i);
                    Inventory.instance.Add(letter1);
                    Inventory.instance.Add(letter2);
                    Inventory.instance.Add(letter3);
                    Inventory.instance.Add(letter4);
                }
            }

        }

    }

}
