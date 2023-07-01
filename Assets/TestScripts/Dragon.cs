using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : Pet
{
    protected override void Speak()
    {
        Debug.Log("Roar");
    }
}
