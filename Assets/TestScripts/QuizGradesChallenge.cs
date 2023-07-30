using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class QuizGradesChallenge : MonoBehaviour
{
    public int[] quizGrades = { 85, 32, 34, 77, 100, 98, 86, 47, 61 };

    public List<int> passingGrades = new List<int>();

    public void Start()
    {
        var passingGrade = quizGrades.Where(grade => grade > 69);
        foreach (var grades in passingGrade)
        {
            passingGrades.Add(grades);
        }
    }
}
