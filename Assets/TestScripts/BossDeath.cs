using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeath : MonoBehaviour
{
    public delegate void BossDied();
    public static event BossDied bossDied;

    private void Start()
    {
        Destroy(gameObject, 3);
    }

    public void OnDestroy()
    {
        if (bossDied != null) //checks to see if a method has been added 
        {
            bossDied(); //runs all methods that have been added
        }
    }
}
