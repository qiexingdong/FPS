using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 枪，提供更换弹夹，开火功能
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class Gun : MonoBehaviour
{
    public float atk = 10;
    public GameObject bulletPrefab;
    public Transform firePoint;//枪口的位置
    private AudioSource source;
    public AudioClip clipFire, clipUpdate;
    private GunAnimation anim;
    private HandFire fire;
    protected virtual void Start()
    {
        source = this.GetComponent<AudioSource>();
        anim = this.GetComponent<GunAnimation>();
        fire = this.GetComponent<HandFire>();
    }
    /// <summary>
    /// 开火发射
    /// </summary>
    /// <param name="destination">枪口指向的方向</param>
    public void Firing(Vector3 destination)
    {
        //查询子弹容量    
        if (anim != null && (CheckBullet() == false || anim.action.IsPlaying(anim.fire)))
            return;
        ammoBullets--;
        //发射子弹:创建子弹、播放动画、播放声音
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(destination));
        bullet.GetComponent<Bullet>().atk = atk;//配置信息
        if (anim != null)
            anim.action.Play(anim.fire);
        fire.Fire();
        source.PlayOneShot(clipFire);
    }
    //弹匣最大容量
    public int ammoCapcity = 4;
    //弹匣已有子弹
    public int ammoBullets = 3;
    //背包子弹数量
    public int bagCapcity = 8;
    /// <summary>
    /// 判断有没有子弹
    /// </summary>
    /// <returns></returns>
    public bool CheckBullet()
    {
        if (ammoBullets > 0 && !anim.action.IsPlaying(anim.updateAmmo))
            return true;
        return false;
    }
    /// <summary>
    /// 更换子弹
    /// </summary>
    public void UpdateAmmo()
    {
        if (ammoBullets == ammoCapcity || bagCapcity <= 0)
            return;
        int num = ammoCapcity - ammoBullets;
        if (bagCapcity >= num)
        {
            ammoBullets = ammoCapcity;
            bagCapcity -= num;
            anim.action.Play(anim.updateAmmo);
            source.PlayOneShot(clipUpdate);
        }
        else
        {
            ammoBullets += bagCapcity;
            bagCapcity = 0;
            anim.action.Play(anim.updateAmmo);
            source.PlayOneShot(clipUpdate);
        }
    }
}


