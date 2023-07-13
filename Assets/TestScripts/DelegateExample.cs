using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateExample : MonoBehaviour
{
    public delegate void SetStats();
    public SetStats setAllStats;

    public void Start()
    {
        setAllStats += SetName;
        setAllStats += SetHealthStat;
        setAllStats += SetAttackStat;
        setAllStats += SetDefenceStat;

        setAllStats();

        setAllStats -= SetName;
    }

    public void SetName()
    {
        Debug.Log("Player name is Link");
    }

    public void SetHealthStat()
    {
        Debug.Log("Health 100");
    }

    public void SetAttackStat()
    {
        Debug.Log("Attack 15");
    }

    public void SetDefenceStat()
    {
        Debug.Log("Defence 8");
    }
}
