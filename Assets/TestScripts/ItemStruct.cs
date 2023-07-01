using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Value Types: bool, bytes, char, doubles, float, int, long, struct
public struct ItemStruct // Value Type - Stack
{
    public string name;
    public int itemID;

    public ItemStruct(string name, int itemID)
    {
        this.name = name;
        this.itemID = itemID;
    }
}

//Reference Types: strings, all arrays, class, and delegates
public class ItemClass // Referemce Type - Heap
{
    public string name;
    public int itemID;

    public ItemClass(string name, int itemID)
    {
        this.name = name;
        this.itemID = itemID;
    }
}

public class ItemStructTesting : MonoBehaviour
{
    public ItemClass ironSword = new ItemClass("Iron Sword", 1);

    public ItemStruct apple;

    private void Start()
    {
        apple.name = "Apple";
        apple.itemID = 2;

    }
}
