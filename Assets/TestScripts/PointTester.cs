using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTester : MonoBehaviour
{
    public PointManager pointManger;

    private void Start()
    {
        pointManger = GameObject.Find("PointManager").GetComponent<PointManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PointManager.currentScore += 10;
            PointManager.CheckHighScore();
        }
    }
}
