using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoSingleton<PoolManager>
{
    [SerializeField]
    private Transform _objectPool;

    public List<GameObject> bullets;

    private int _bulletIdx;

    public GameObject GetBullet()
    {
        GameObject newBullet = bullets[_bulletIdx];

        _bulletIdx++;
        int newIdx = _bulletIdx > (bullets.Count - 1) ? 0 : _bulletIdx;
        _bulletIdx = newIdx;

        return newBullet;
    }

    public void ReturnObjectToPool(GameObject obj)
    {
        obj.transform.position = _objectPool.position;
        obj.transform.rotation = _objectPool.rotation;
    }
}
