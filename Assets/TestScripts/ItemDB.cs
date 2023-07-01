using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDB : MonoBehaviour
{
    public List<Item> itemDatabase = new List<Item>();

    public void CheckForMatchingItem(int itemID, bool addItem, PlayerInventory inventory)
    {
        foreach (var item in itemDatabase)
        {
            if (item.index == itemID)
            {
                Debug.Log("Found matching item");

                if (addItem) { inventory.inventory[0] = item; }
                else { inventory.inventory[0] = null; }

                return;
            }
        }

        Debug.Log("No item match was found");
    }
}
