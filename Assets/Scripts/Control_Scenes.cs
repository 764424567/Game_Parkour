using System.Collections.Generic;
using UnityEngine;

public class Control_Scenes : MonoBehaviour
{
    //障碍物数组对象
    public GameObject[] m_ObstacleArray;
    //障碍物的点的数组对象
    public List<Transform> m_ObstaclePosArray = new List<Transform>();
    //道路列表
    public GameObject[] m_RoadArray;
    //第一次
    private bool m_ISFirst = true;

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            Spawn_Obstacle(i);
        }
    }

    public void Change_Road(int index)
    {
        if (m_ISFirst && index == 0)
        {
            m_ISFirst = false;
            return;
        }
        else
        {
            int lastIndex = index - 1;
            if (lastIndex < 0)
                lastIndex = 2;
            m_RoadArray[lastIndex].transform.position = m_RoadArray[lastIndex].transform.position - new Vector3(150, 0, 0);
            Spawn_Obstacle(lastIndex);
        }
    }

    public void Spawn_Obstacle(int index)
    {
        //销毁原来的对象
        GameObject[] obsPast = GameObject.FindGameObjectsWithTag("Obstacle" + index);
        for (int i = 0; i < obsPast.Length; i++)
        {
            Destroy(obsPast[i]);
        }
        //生成障碍物
        foreach (Transform item in m_ObstaclePosArray[index])
        {
            GameObject prefab = m_ObstacleArray[Random.Range(0, m_ObstacleArray.Length)];
            Vector3 eulerAngle = new Vector3(0, Random.Range(0, 360), 0);
            GameObject obj = Instantiate(prefab, item.position, Quaternion.Euler(eulerAngle));
            obj.tag = "Obstacle" + index;
        }
    }
}
