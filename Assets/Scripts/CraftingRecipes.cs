using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/* Sits on all InventorySlots. */

public class CraftingRecipes : MonoBehaviour
{
    public Item key;

    public static Item staticKey;// Current item in the slot

    private void Awake()
    {
        staticKey = key;
    }

    public static Item ReadWord(string word)
    {

        switch (word)
        {
            case "KEY":
                return staticKey;
            default:
                return null;
        }

    }
    
}
