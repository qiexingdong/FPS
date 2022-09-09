using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 敌人
/// </summary>
[RequireComponent(typeof(EnemyMotor))]
[RequireComponent(typeof(EnemyAnimation))]
[RequireComponent(typeof(EnemyStatus))]
public class EnemyAI : MonoBehaviour
{
    private enum State
    {
        Run,
        Attack,
        Die,
    }
    private State state = State.Run;
    private EnemyMotor motor;
    private EnemyAnimation anim;
    private float time;
    public float intervalTime = 4;
    private Gun gun;
    public float delayTime;
    private void Start()
    {
        motor = this.GetComponent<EnemyMotor>();
        anim = this.GetComponent<EnemyAnimation>();
        gun = this.GetComponent<Gun>();
    }
    private void Update()
    {
        switch (state)
        {
            case State.Run:
                anim.action.Play(anim.runAnim);
                if (motor.PathFind() == false)
                    state = State.Attack;
                break;
            case State.Attack:
                Attack();
                break;
        }
    }
    private void Attack()
    {
        this.transform.rotation = Quaternion.LookRotation(PlayerStatus.Instance.footTF.position-this.transform.position);
        //面向玩家
        if (Time.time >= time)
        {
            anim.action.Play(anim.attackAnim);//动画
            Invoke("Shooting",delayTime);
            time = Time.time + intervalTime;
        }
        if (anim.action.IsPlaying(anim.attackAnim) == false)
            anim.action.Play(anim.idleAnim);//动画
    }
    private void Shooting()
    {
        gun.Firing(PlayerStatus.Instance.headTF.position - gun.firePoint.position);//发射
    }
}


