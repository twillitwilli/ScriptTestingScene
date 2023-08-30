using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _bulletSpeed;

    private async void OnEnable()
    {
        await Task.Delay(2000);

        gameObject.SetActive(false);
    }

    private void Update()
    {
        transform.Translate(Vector3.up * _bulletSpeed * Time.deltaTime);
    }

    private void OnDisable()
    {
        PoolManager.Instance.ReturnObjectToPool(gameObject);
    }
}
