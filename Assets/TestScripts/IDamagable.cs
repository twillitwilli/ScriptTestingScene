using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable <T>
{
    float Health { get; set; }

    void Damage(T damageAmount);

    void Death();
}
