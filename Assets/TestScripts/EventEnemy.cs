using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventEnemy : MonoBehaviour
{
    private void Start()
    {
        BossDeath.bossDied += KillEnemy; //this adds the method to the event
    }

    public void KillEnemy()
    {
        Destroy(gameObject, 2);
    }
}
