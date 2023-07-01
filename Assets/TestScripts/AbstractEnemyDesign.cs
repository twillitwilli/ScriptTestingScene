using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEnemyDesign : MonoBehaviour
{
    public float movementSpeed;
    public float attackDamage;
    public float health;

    public abstract void Attack();

    public void Dead()
    {

    }
}
