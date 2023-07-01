using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CreditUnionData : BankData
{
    public int availableCashToLend;

    public void LoanApproved()
    {
        Debug.Log("You were approved for the loan!");
    }

    public void LoanDeclined()
    {
        Debug.Log("Sorry to inform you, your loan was declined.");
    }
}
