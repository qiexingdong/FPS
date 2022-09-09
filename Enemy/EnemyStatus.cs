using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 敌人状态信息
/// </summary>
public class EnemyStatus : MonoBehaviour
{
    public float PH = 100;
    public float maxPH = 100;
    public float dieTime = 3;
    [HideInInspector]
    public EnemySpawn spawn;
    EnemyAnimation enemy;
    private void Start()
    {
        enemy = GetComponent<EnemyAnimation>();
    }
    /// <summary>
    /// 受伤
    /// </summary>
    /// <param name="amount"></param>
    public void Damage(float amount)
    {
        if (PH <= 0)
            return;
        PH -= amount;
        if (PH <= 0)
            Die();
        
    }
    /// <summary>
    /// 死亡
    /// </summary>
    public void Die()
    {
        enemy.action.Play(enemy.dieAnim);//播放死亡动画
        Destroy(gameObject, dieTime);//摧毁gb
        this.GetComponent<EnemyMotor>().points.IsUsable = true;
        spawn.GenerateEnemy();
        this.GetComponent<EnemyAI>().enabled = false;//禁用ai脚本
    }
}


