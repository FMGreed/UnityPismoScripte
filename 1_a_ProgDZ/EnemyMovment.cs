using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyMovment : MonoBehaviour {


    private Transform target;
    private int wavepointIndex = 0;

    private Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();

        target = Waypoints.points[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }

        enemy.speed = enemy.startSpeed;

        if ( wavepointIndex == 0)
        {
            transform.Rotate(0, 0, 0);
        }
        else if ( wavepointIndex == 3)
        {
            transform.rotation = Quaternion.AngleAxis(47, Vector3.up);
        }
        else if (wavepointIndex == 4)
        {
            transform.rotation = Quaternion.AngleAxis(121, Vector3.up);
        }
        else if (wavepointIndex == 5)
        {
            transform.rotation = Quaternion.AngleAxis(150, Vector3.up);
        }
        else if (wavepointIndex == 6)
        {
            transform.rotation = Quaternion.AngleAxis(96, Vector3.up);
        }
        else if (wavepointIndex == 7)
        {
            transform.rotation = Quaternion.AngleAxis(70, Vector3.up);
        }
        else if (wavepointIndex == 8)
        {
            transform.rotation = Quaternion.AngleAxis(13, Vector3.up);
        }
        else if (wavepointIndex == 9)
        {
            transform.rotation = Quaternion.AngleAxis(-38, Vector3.up);
        }
        else if (wavepointIndex == 10)
        {
            transform.rotation = Quaternion.AngleAxis(-52, Vector3.up);
        }
        else if (wavepointIndex == 11)
        {
            transform.rotation = Quaternion.AngleAxis(-60, Vector3.up);
        }
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpavner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
