using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private ItemDB _itemDatabase;
    public Item[] inventory = new Item[10]; //10 inventory slots available

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _itemDatabase.CheckForMatchingItem(0, true, this);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            _itemDatabase.CheckForMatchingItem(0, false, this);
        }
    }
}
