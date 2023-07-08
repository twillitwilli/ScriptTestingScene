using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartTimeEmployee : AbstractEmployeeClass
{
    public float hoursWorked;
    public float hourlyRate;

    public override void CalculateMonthlyPay()
    {
        int monthlyPay = Mathf.RoundToInt(hoursWorked * hourlyRate);
        Debug.Log(companyName + " pays " + employeeName + " : $" + monthlyPay);
    }
}
