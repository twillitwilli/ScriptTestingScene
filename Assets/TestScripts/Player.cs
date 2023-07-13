using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamagable<int>
{
    public float Health { get; set; }

    public void Start()
    {
        Health = 100;
    }

    public void Damage(int damageAmount)
    {
        Health += damageAmount;

        if (Health <= 0) { Death(); }
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
