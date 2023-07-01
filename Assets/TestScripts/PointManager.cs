using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public static int currentScore, highScore;

    public static void CheckHighScore()
    {
        if (currentScore > highScore) { highScore = currentScore; }
    }
}
