using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TrackingInfo
{
    public int totalLines;

    public int lengthOfLine;

    public float[]
        trackedPosX,
        trackedPosY,
        trackedPosZ;
}
