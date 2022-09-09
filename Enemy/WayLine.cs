using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Â·ÏßÀà
/// </summary>
public class WayLine
{
    public Vector3[] Point { get; set; }
    public bool IsUsable { get; set; }
    public WayLine(Transform index) {
        Point = new Vector3[index.childCount];
        IsUsable = true;
    } 
}
