using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelSystem : MonoBehaviour
{
    [SerializeField] private GameObject levelUpEffect;

    private void Start()
    {
        BossDeath.bossDied += PlayerLeveledUp;
    }

    public void PlayerLeveledUp()
    {
        Debug.Log("Player Leveled Up!!!");
        Instantiate(levelUpEffect, transform.position, transform.rotation);
    }
}
