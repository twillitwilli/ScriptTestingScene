using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private Transform _bulletSpawnLocation;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newBullet = PoolManager.Instance.GetBullet();

            newBullet.transform.position = _bulletSpawnLocation.position;
            newBullet.transform.rotation = _bulletSpawnLocation.rotation;

            newBullet.SetActive(true);
        }
    }
}
