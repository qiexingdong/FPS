using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �ӵ�
/// </summary>
public class Bullet : MonoBehaviour
{
    public float atk;//�˺�
    public float distance = 100;//�ӵ�����ľ���
    public float speed = 10;//�ӵ�������ٶ�
    public LayerMask mask;//ͼ��
    private Vector3 point;//�ӵ��򵽵�Ŀ��
    protected RaycastHit hit;//����
    protected virtual void Awake()
    {
        GetTargePoint();
    }
    /// <summary>
    /// ��������
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
    /// �ӵ��ƶ�
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
    /// ������ͼ
    /// </summary>
    private void GenerateContactEffects()
    {
        //GameObject effect = Resources.Load<GameObject>("Ŀ¼/��Դ����")����ͨ��ѡ�������ж�ȡ����̫����
        //[����ʹ�ó��������],�Ժ��ѧ
        GameObject effect = Resources.Load<GameObject>("ContactEffects/Effects" + hit.collider.tag);//��ȡ��Դ
        Instantiate(effect,point, Quaternion.LookRotation(-hit.normal));//������Դ
    }
}
