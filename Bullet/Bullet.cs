using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 子弹
/// </summary>
public class Bullet : MonoBehaviour
{
    public float atk;//伤害
    public float distance = 100;//子弹发射的距离
    public float speed = 10;//子弹发射的速度
    public LayerMask mask;//图层
    private Vector3 point;//子弹打到的目标
    protected RaycastHit hit;//射线
    protected virtual void Awake()
    {
        GetTargePoint();
    }
    /// <summary>
    /// 发射射线
    /// </summary>
    private void GetTargePoint()
    {
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, distance, mask))
            point = hit.point;
        else
            point = this.transform.position + distance * this.transform.forward;
    }
    private void Update()
    {
        Movement();
    }
    /// <summary>
    /// 子弹移动
    /// </summary>
    private void Movement()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, point, speed * Time.deltaTime);
        if (Vector3.Distance(this.transform.position, point) < 0.1f)
        {
            GenerateContactEffects();
            Destroy(gameObject);
        }
    }
    /// <summary>
    /// 生成贴图
    /// </summary>
    private void GenerateContactEffects()
    {
        //GameObject effect = Resources.Load<GameObject>("目录/资源名称")，可通过选择语句进行读取，但太繁琐
        //[建议使用常量池替代],以后会学
        GameObject effect = Resources.Load<GameObject>("ContactEffects/Effects" + hit.collider.tag);//读取资源
        Instantiate(effect,point, Quaternion.LookRotation(-hit.normal));//创建资源
    }
}
