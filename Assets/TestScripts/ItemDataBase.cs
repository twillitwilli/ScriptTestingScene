using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataBase : MonoBehaviour
{
    [SerializeField] private Item[] _items;
    [SerializeField] private Weapon[] _weapons;
    [SerializeField] private Consumable[] _consumables;
}