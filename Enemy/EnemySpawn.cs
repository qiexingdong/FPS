using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ����������
/// </summary>
public class EnemySpawn : MonoBehaviour
{
    /// <summary>
    /// ����Ԥ�Ƽ��ĸ���
    /// </summary>
    public GameObject[] enemyType;
    public int maxMount = 5;
    public int startMount = 2;
    /// <summary>
    /// ���˵�ǰ����
    /// </summary>
    public int currentMount = 2;
    private WayLine[] wayLines;
    //��һ��ʱ�����ɵ���
    public void CreateEnemy()
    {
        if (currentMount >= maxMount)
            return;
        int intervalTime = Random.Range(1, 11);
        Invoke("GenerateEnemy", intervalTime);
    }
    //���ɵ���
    public void GenerateEnemy()
    {
        WayLine[] realLines = SelectLines();
        if (realLines.Length > 0)
        {
            int random1 = Random.Range(0, enemyType.Length);
            int random2 = Random.Range(0, realLines.Length);
            GameObject go =
            Instantiate(enemyType[random1], realLines[random2].Point[0], Quaternion.identity);
            EnemyMotor motor = go.GetComponent<EnemyMotor>();
            motor.points = realLines[random2];
            realLines[random2].IsUsable = false;
            go.GetComponent<EnemyStatus>().spawn = this;
        }
    }
    //����·��
    public void CalculateWayLines()
    {
        wayLines = new WayLine[this.transform.childCount];
        for (int i = 0; i < this.transform.childCount; i++)
        {
            Transform index = this.transform.GetChild(i);
            wayLines[i] = new WayLine(index);
            for (int j = 0; j < index.childCount; j++)
            {
                wayLines[i].Point[j] = index.GetChild(j).position;
            }
        }
    }
    //��ѡ·��
    public WayLine[] SelectLines()
    {
        List<WayLine> arr = new List<WayLine>(wayLines.Length);
        for (int i = 0; i < wayLines.Length; i++)
        {
            if (wayLines[i].IsUsable == true)
                arr.Add(wayLines[i]);
        }
        return arr.ToArray();
    }

    private void Start()
    {
        CalculateWayLines();
        for (int i = 0; i < startMount; i++)
        {
            GenerateEnemy();
        }
        CreateEnemy();
    }
}


