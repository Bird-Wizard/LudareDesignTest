using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{
    public GameObject[] WayPoints;

    public float Speed = 2.0f;

    void Update()
    {
        if (Vector2.Distance(WayPoints[m_WayPointIndex].transform.position, transform.position) < 0.1f)
        {
            m_WayPointIndex++;
            if (m_WayPointIndex >= WayPoints.Length)
            {
                m_WayPointIndex = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, WayPoints[m_WayPointIndex].transform.position, Time.deltaTime * Speed);
    }

    private int m_WayPointIndex = 0;
}
