using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomizeAList : MonoBehaviour
{
    [SerializeField]
    List<Item> _itemList;

    [SerializeField]
    List<Item> _randomizedList = new List<Item>();

    public void Start()
    {
        _randomizedList = _itemList.OrderBy(x => Random.value).ToList();
    }
}
