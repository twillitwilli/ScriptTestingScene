using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TrackingInfo
{
    public int savedFrames;

    public bool[] markerInUseDuringFrame;

    public float[]
        trackedPosX,
        trackedPosY,
        trackedPosZ;
}
