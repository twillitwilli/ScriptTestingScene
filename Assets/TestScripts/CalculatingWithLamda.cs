using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using unityEngine = UnityEngine;

public class CalculatingWithLamda : MonoBehaviour
{
    [SerializeField] private bool usingLambda;

    public Action<int, int> Sum;
    private void Start()
    {
        if (usingLambda) { UsingLambda(); }
        else NotUsingLambda();
    }
    private void UsingLambda()
    {
        // Using Lamda I can remove the entire CalculateSum method
        Sum += (a, b) =>
        {
            var total = a + b;

            //To replace the if else statement I can also use a ?: operator
            string message = total < 100 ? "Total is less than 100" : "Total: " + total;
            Debug.Log(message);
        };

        Sum(unityEngine::Random.Range(0, 100), unityEngine::Random.Range(0, 100));
    }
    private void NotUsingLambda()
    {
        Sum += CalculateSum;

        Sum(unityEngine::Random.Range(0, 100), unityEngine::Random.Range(0, 100));
    }
    private void CalculateSum(int a, int b)
    {
        var total = a + b;

        if (total < 100)
        {
            Debug.Log("Total is less than 100");
        }
        else Debug.Log("Total: " + total);
    }
}
