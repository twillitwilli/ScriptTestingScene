using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public delegate void DamageTaken(int currentHealth);
    public static event DamageTaken damaged;

    public static Action<int> healed; //an action takes the place of both the delegate and event and stores it as one

    public int Health { get; set; }

    private void Start()
    {
        Health = 100;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Damaged();
        }

        else if (Input.GetKeyDown(KeyCode.H))
        {
            Healed();
        }
    }

    private void Damaged()
    {
        Health -= 15;
        if (Health <= 0) { Health = 0; }

        if (damaged != null)
        {
            damaged(Health);
        }
    }

    private void Healed()
    {
        Health += 15;
        if (Health >= 100) { Health = 100; }

        if (healed != null)
        {
            healed(Health);
        }
    }
}
