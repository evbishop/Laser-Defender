using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    List<Transform> waypoints;
    int waypointIndex = 0;

    public WaveConfig WaveConfiguration { get; set; }

    void Start()
    {
        waypoints = WaveConfiguration.Waypoints;
        transform.position = waypoints[waypointIndex].transform.position;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            transform.position = UnityEngine.Vector2.MoveTowards(
                transform.position,
                targetPosition,
                WaveConfiguration.MoveSpeed * Time.deltaTime);

            if (transform.position == targetPosition)
                waypointIndex++;
        }
        else Destroy(gameObject);
    }
}
