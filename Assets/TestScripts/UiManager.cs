using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    [SerializeField] private TMP_Text enemyCounterText;

    public void Awake()
    {
        if (!instance) { instance = this; }
    }

    public void UpdateEnemyCounter()
    {
        enemyCounterText.text = "Enemy Count: " + SpawnManager.enemyCount;
    }
}
