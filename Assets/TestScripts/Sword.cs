using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponPack.MeleeWeapons;

public class Sword : MonoBehaviour
{
    private Weapons weapons = new Weapons();

    public float damage;

    private void Start()
    {
        weapons.Attack();
    }
}
