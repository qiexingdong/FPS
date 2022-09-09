using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ����״̬��Ϣ
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
    /// ����
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
    /// ����
    /// </summary>
    public void Die()
    {
        enemy.action.Play(enemy.dieAnim);//������������
        Destroy(gameObject, dieTime);//�ݻ�gb
        this.GetComponent<EnemyMotor>().points.IsUsable = true;
        spawn.GenerateEnemy();
        this.GetComponent<EnemyAI>().enabled = false;//����ai�ű�
    }
}


