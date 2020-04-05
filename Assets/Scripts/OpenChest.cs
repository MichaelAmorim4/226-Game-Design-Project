using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : Interactable
{

    public Sprite sprite; // Item to put in the inventory if picked up
    public Item letter1;
    public Item letter2;
    public Item letter3;

    // When the player interacts with the item
    public override void Interact()
    {
        base.Interact();

        OpenItem();
    }

    // Pick up the item
    void OpenItem()
    {

        SpriteRenderer spriteR = GetComponent<SpriteRenderer>();
        spriteR.sprite = sprite;

        Inventory.instance.Add(letter1);
        Inventory.instance.Add(letter2);
        Inventory.instance.Add(letter3);

        Destroy(GetComponent<OpenChest>());

    }

}