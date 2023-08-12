using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LambdaReturnType : MonoBehaviour
{
    public Func<int> onGetName;

    private void Start()
    {
        // Using lambda is like a way of not writing in a seperate method and just having it all contained better
        onGetName += () => this.gameObject.name.Length;

        int lengthOfName = onGetName();

        Debug.Log("Length of Name: " + lengthOfName);
    }
}
