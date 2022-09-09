using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// µÐÈË×Óµ¯
/// </summary>
public class EnemyBullet : Bullet
{
    //protected override void Start()
    //{
    //    base.Start();
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainCamera") {
            PlayerStatus.Instance.Damage(atk);
            Destroy(gameObject);
        }
    }
}
