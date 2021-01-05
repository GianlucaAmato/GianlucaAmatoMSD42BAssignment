using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePath : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;

    [SerializeField] WaveConfiguration waveConfiguration;

    
    int waypointIndex = 0;

    void Start()
    {
        waypoints = waveConfiguration.GetWaypoints();

        transform.position = waypoints[waypointIndex].transform.position;

    }

    void Update()
    {
        ObstacleMove();
    }

    private void ObstacleMove()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;

            targetPosition.z = 0f;

            var enemyMovement = waveConfiguration.GetObstacleMoveSpeed() * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, enemyMovement);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }

        else
        {
            Destroy(gameObject);
        }

       
    }

}
