using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public static PlayerStatus Instance { get;private set; }
    public Transform headTF;
    public Transform footTF;
    private void Awake()
    {
        Instance = this;
    }
    public float PH = 1000;
    public float maxPH = 1000;
    public void Damage(float amount)
    {
        PH -= amount;
        if (PH <= 0)
            Die();
    }
    public void Die() {
        Debug.Log("ÄãËÀÁË");
    }
}
