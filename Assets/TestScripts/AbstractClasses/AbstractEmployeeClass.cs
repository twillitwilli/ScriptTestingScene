using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEmployeeClass : MonoBehaviour
{
    public string companyName = "Game Dev HQ";
    public string employeeName;

    public void Start()
    {
        CalculateMonthlyPay();
    }

    public abstract void CalculateMonthlyPay();
}
