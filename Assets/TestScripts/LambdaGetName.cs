using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LambdaGetName : MonoBehaviour
{
    public Action onGetName;
    private void Start()
    {
        // Using this delegate, first no parameters are being entered, then using the lambda expression
        // the debug messages are added to the onGetName action delegate.
        onGetName += () =>
        {
            Debug.Log("Name: " + gameObject.name);
            Debug.Log("Using Lambda");
        };

        // Then I can call the action delegate to let it run
        onGetName();
    }
}
