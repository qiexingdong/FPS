using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Íæ¼Ò×Óµ¯
/// </summary>
public class PlayerBullet : Bullet
{
    //protected override void Start()
    //{
    //    base.Start();
    //} 
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Enemy")
    //    {
    //        float atk = CalculateATK();
    //        other.GetComponentInParent<EnemyStatus>().Damage(atk);
    //        Destroy(gameObject);
    //    }
    //}
    private void Start()
    {
        float atk = CalculateATK();
        if (hit.collider != null && hit.collider.tag == "Enemy")
        {
            hit.collider.GetComponentInParent<EnemyStatus>().Damage(atk);
        }
    }
    private float CalculateATK()
    {
        switch (base.hit.collider.name)
        {
            case "Coll_Body":
                return base.atk * 2;
            case "Coll_Head":
                return base.atk * 10;
            default:
                return base.atk;
        }
    }
}
