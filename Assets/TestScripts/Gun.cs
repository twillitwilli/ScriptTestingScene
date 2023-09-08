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
            GameObject newBullet = BulletPoolManager.Instance.GetItem();

            newBullet.transform.position = _bulletSpawnLocation.position;
            newBullet.transform.rotation = _bulletSpawnLocation.rotation;

            newBullet.SetActive(true);
        }
    }
}
