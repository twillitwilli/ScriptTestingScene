using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDictionary : MonoBehaviour
{
    public enum LoopType { loopEntireDictionary, loopOnlyThroughKeys, loopOnlyThroughReferences }
    public LoopType dictionaryLoopType;

    //Dictionary < Key variable, then reference variable >
    public Dictionary<int, Item> itemDictionary = new Dictionary<int, Item>();

    private void Start()
    {
        CreateItems();
        PrintItemDictionaryInfo();
    }

    private void CreateItems()
    {
        Item masterSword = new Item();
        masterSword.name = "Master Sword";
        masterSword.index = 0;

        Item fairyBow = new Item();
        fairyBow.name = "Fariy Bow";
        fairyBow.index = 1;

        Item hookshot = new Item();
        hookshot.name = "Hookshot";
        hookshot.index = 2;

        //Add Items to Dictionary
        itemDictionary.Add(0, masterSword);
        itemDictionary.Add(1, fairyBow);
        itemDictionary.Add(2, hookshot);
    }

    private void PrintItemDictionaryInfo()
    {
        switch (dictionaryLoopType)
        {
            case LoopType.loopEntireDictionary:
                foreach (KeyValuePair<int, Item> item in itemDictionary)
                {
                    Debug.Log("Key: " + item.Key);
                    Debug.Log("Value: " + item.Value.name);
                }

                break;

            case LoopType.loopOnlyThroughKeys:
                foreach (int key in itemDictionary.Keys)
                {
                    Debug.Log("Key: " + key);
                }

                break;

            case LoopType.loopOnlyThroughReferences:
                foreach (Item item in itemDictionary.Values)
                {
                    Debug.Log("Value: " + item.name);
                }

                break;
        }  
    }
}
