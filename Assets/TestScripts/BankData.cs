using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BankData
{
    public string branchName;
    public string location;
    public int totalMoney;

    public void CheckBalance()
    {
        Debug.Log("Checking Balancing From: " + branchName);
    }

    public void Withdrawl()
    {
        Debug.Log("Withdrawling From: " + branchName);
    }

    public void Deposit()
    {
        Debug.Log("Depositing At: " + branchName);
    }
}
