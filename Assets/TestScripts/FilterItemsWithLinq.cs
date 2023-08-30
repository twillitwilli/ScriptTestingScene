using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FilterItemsWithLinq : MonoBehaviour
{
    public enum FilterType { itemIdExists, grabItemsWithValueGreaterThan, calculateAverageValue }
    public FilterType filterType;

    [SerializeField]
    private int _value;

    [SerializeField]
    private bool _runCheck;

    [SerializeField]
    private List<Item> _items;

    private void Update()
    {
        if (_runCheck)
        {
            switch (filterType)
            {
                case FilterType.itemIdExists:
                    var result = _items.Any(item => item.index == _value);

                    Debug.Log("Item ID Exists = " + result);
                    break;

                case FilterType.grabItemsWithValueGreaterThan:
                    var itemCollection = _items.Where(item => item.value > _value);

                    foreach (var item in itemCollection)
                    {
                        Debug.Log("Item Name = " + item.name + "\nItem Value = " + item.value);
                    }
                    break;

                case FilterType.calculateAverageValue:
                    var averageResult =_items.Average(item => item.value);

                    Debug.Log("Total Average Value = " + averageResult);
                    break;
            }

            _runCheck = false;
        }
    }
}
