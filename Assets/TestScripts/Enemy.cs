using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnEnable()
    {
        SpawnManager.enemyCount++;
        UiManager.instance.UpdateEnemyCounter();
        Die();
    }

    private void Die()
    {
        Destroy(gameObject, Random.Range(2.5f, 6));
    }

    private void OnDisable()
    {
        SpawnManager.enemyCount--;
        UiManager.instance.UpdateEnemyCounter();
    }
}
