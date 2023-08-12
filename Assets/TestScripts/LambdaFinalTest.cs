using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LambdaFinalTest : MonoBehaviour
{
    /// Create a delegate of type int that takes 2 numbers as a parameter and adds the sum
    /// 

    // in Func the last variable added is always a return variable. so in this case the int's will be
    // parameters that can be passed in (like private void CalculateSum(int a, int b) {}), and the string would be
    // a return type (private string CalculateSum(int a, int b) {})
    public Func<int, int, string> onCalculateSum;
    private void Start()
    {
        onCalculateSum += (a, b) => (a + b).ToString();

        Debug.Log("The Sum = " + onCalculateSum(5, 10));
    }

    // I could calculate the sum using this method
    private int CalculateSum(int a, int b)
    {
        return a + b;
    }
}
