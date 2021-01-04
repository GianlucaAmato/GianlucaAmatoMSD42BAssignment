using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Obstacle Wave Configuration")]
public class WaveConfiguration : ScriptableObject
{
    [SerializeField] GameObject obstaclePrefab;

    [SerializeField] GameObject pathPrefab;

    [SerializeField] float timeBetweenObstacles = 0.5f;

    [SerializeField] int numberOfObstacles = 5;

    [SerializeField] float obstacleMoveSpeed = 2f;

    public GameObject GetObstaclePrefab()
    {
        return obstaclePrefab;
    }

    public List<Transform> GetWaypoints()
    {
        var waveWayPoints = new List<Transform>();

        foreach (Transform Waypoint in pathPrefab.transform)
        {
            waveWayPoints.Add(Waypoint);
        }

        return waveWayPoints;

    }

    public float GetTimeBetweenObstacles()
    {
        return timeBetweenObstacles;
    }

    public float GetNumberOfObstacles()
    {
        return numberOfObstacles;
    }

    public float GetObstacleMoveSpeed()
    {
        return obstacleMoveSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
