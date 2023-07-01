using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    [SerializeField] protected string _name;

    private void Start()
    {
        Speak();
    }

    protected virtual void Speak()
    {
        Debug.Log("Speak");
    }
}
