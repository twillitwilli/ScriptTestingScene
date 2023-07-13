using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagerRay : MonoBehaviour
{
    [SerializeField] private GameObject _hitEffect;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray origin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(origin, out hit))
            {
                IDamagable<int> damagableObj = hit.collider.GetComponent<IDamagable<int>>();

                if (damagableObj != null)
                {
                    Instantiate(_hitEffect);
                    damagableObj.Damage(-25);
                }
            }
        }
    }
}
