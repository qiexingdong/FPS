using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 敌人运动
/// </summary>
public class EnemyMotor : MonoBehaviour
{
    public WayLine points;
    public float moveSpeed = 10;
    private int currentPointIndex = 0;
    /// <summary>
    /// 行走
    /// </summary>
    public void MovementForward()
    {
        this.transform.Translate(0, 0, moveSpeed * Time.deltaTime);
    }
    /// <summary>
    /// 旋转
    /// </summary>
    /// <param name="point">目标坐标</param>
    public void LookRotation(Vector3 point)
    {
        this.transform.LookAt(point);
    }
    /// <summary>
    /// 寻路
    /// </summary>
    public bool PathFind()
    {
        if (points == null || currentPointIndex >= points.Point.Length)
            return false;
        LookRotation(points.Point[currentPointIndex]);
        MovementForward();
        if (Vector3.Distance(this.transform.position, points.Point[currentPointIndex]) < 0.5f)
            currentPointIndex++;
        return true;
    }
}



