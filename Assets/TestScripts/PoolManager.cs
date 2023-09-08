using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PoolManager<T> : MonoBehaviour where T : PoolManager<T>
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
                Debug.Log(typeof(T).ToString() + " is NULL");

            return _instance;
        }
    }

    [SerializeField]
    private GameObject _itemPrefab;

    private List<GameObject> _itemPool = new List<GameObject>();

    private int _itemIndex;

    private void Awake()
    {
        _instance = this as T;
    }

    public GameObject GetItem()
    {
        GameObject newItem;

        if (_itemPool.Count < 1)
            newItem = SpawnNewItem(_itemPrefab, _itemPool);

        if (!_itemPool[0].activeSelf)
        {
            newItem = _itemPool[0];
            _itemIndex = 0;
        }

        else
        {
            _itemIndex++;
            _itemIndex = _itemIndex > (_itemPool.Count - 1) ? 0 : _itemIndex;

            newItem = GetItemFromPool(_itemIndex, _itemPool);
        }

        return newItem;
    }

    GameObject GetItemFromPool(int poolIdx, List<GameObject> whichPool)
    {
        GameObject itemFromPool = null;

        bool spawnNewItem = whichPool[poolIdx].activeSelf ? true : false;

        if (spawnNewItem)
            itemFromPool = SpawnNewItem(_itemPrefab, whichPool);

        else
            itemFromPool = whichPool[poolIdx];

        if (!itemFromPool.activeSelf)
            itemFromPool.SetActive(true);

        return itemFromPool;
    }

    GameObject SpawnNewItem(GameObject newItem, List<GameObject> whichPool)
    {
        GameObject item = Instantiate(newItem);
        whichPool.Add(item);
        item.transform.SetParent(transform);

        return item;
    }

    public void ReturnObjectToPool(GameObject obj)
    {
        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;

        if (obj.activeSelf)
            obj.SetActive(false);
    }
}
