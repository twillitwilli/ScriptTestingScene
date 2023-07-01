using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UtilityHelper
{
    public static GameObject CreateObject(PrimitiveType objectType)
    {
        return GameObject.CreatePrimitive(objectType);
    }

    public static void ResetTransform(GameObject obj)
    {
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localEulerAngles = Vector3.zero;
        obj.transform.localScale = Vector3.one;
    }

    public static void ChangeColor(Material material, Color color, bool randomizeColor)
    {
        if (randomizeColor) { material.color = new Color(Random.value, Random.value, Random.value); }
        else { material.color = color; }
    }
}
