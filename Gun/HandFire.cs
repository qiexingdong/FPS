using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ǹ��
/// </summary>
public class HandFire : MonoBehaviour
{
    public GameObject fire;
    private float time;
    public float lastTime = 0.2f; 
    public void Fire()
    {
        fire.SetActive(true);
        time = Time.time + lastTime;
    }
    private void Update()
    {
        if (Time.time >= time)
        {
            fire.SetActive(false);
        }
    }
}





