using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class PWRandomColors : MonoBehaviour
{
    public PWColor[] randomColors;

    public List<PWColor> colorsToPullFrom;
    public int amountToGrab;
    public bool allowDupes;

    private void Start()
    {
        if (!allowDupes && colorsToPullFrom.Count < amountToGrab)
        {
            Debug.Log("Not enough colors!");
            return;
        }
        else
        {
            randomColors = new PWColor[amountToGrab];

            randomColors = GetRandomColors().GetAwaiter().GetResult();
        }
    }

    private async Task<PWColor[]> GetRandomColors()
    {
        PWColor[] returnColors = new PWColor[amountToGrab];
        System.Random randomizer = new System.Random();

        for (int i = 0; i < amountToGrab; i++)
        {
            int randomColor = randomizer.Next(0, colorsToPullFrom.Count);
            Debug.Log("randomColorInt = " + randomColor);
            returnColors[i] = colorsToPullFrom[randomColor];

            if (!allowDupes)
            {
                colorsToPullFrom.Remove(colorsToPullFrom[randomColor]);
            }
        }

        return returnColors;
    }
}
