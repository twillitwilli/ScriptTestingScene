using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullTimeEmployee : AbstractEmployeeClass
{
    public int salaryAmount;

    public override void CalculateMonthlyPay()
    {
        Debug.Log(companyName + " pays " + employeeName + " : $" + salaryAmount);
    }
}
