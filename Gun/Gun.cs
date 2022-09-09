using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ǹ���ṩ�������У�������
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class Gun : MonoBehaviour
{
    public float atk = 10;
    public GameObject bulletPrefab;
    public Transform firePoint;//ǹ�ڵ�λ��
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
    /// ������
    /// </summary>
    /// <param name="destination">ǹ��ָ��ķ���</param>
    public void Firing(Vector3 destination)
    {
        //��ѯ�ӵ�����    
        if (anim != null && (CheckBullet() == false || anim.action.IsPlaying(anim.fire)))
            return;
        ammoBullets--;
        //�����ӵ�:�����ӵ������Ŷ�������������
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(destination));
        bullet.GetComponent<Bullet>().atk = atk;//������Ϣ
        if (anim != null)
            anim.action.Play(anim.fire);
        fire.Fire();
        source.PlayOneShot(clipFire);
    }
    //��ϻ�������
    public int ammoCapcity = 4;
    //��ϻ�����ӵ�
    public int ammoBullets = 3;
    //�����ӵ�����
    public int bagCapcity = 8;
    /// <summary>
    /// �ж���û���ӵ�
    /// </summary>
    /// <returns></returns>
    public bool CheckBullet()
    {
        if (ammoBullets > 0 && !anim.action.IsPlaying(anim.updateAmmo))
            return true;
        return false;
    }
    /// <summary>
    /// �����ӵ�
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


