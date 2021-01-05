using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfiguration> waveConfigurationList;

    int startingWave = 0;

    void Start()
    {
        var currentWave = waveConfigurationList[startingWave];

        StartCoroutine(SpawnAllObstaclesInWave(currentWave));
    }

    
    void Update()
    {
        
    }

    private IEnumerator SpawnAllObstaclesInWave(WaveConfiguration waveConfiguration)
    {
        Instantiate(
            waveConfiguration.GetObstaclePrefab(),waveConfiguration.GetWaypoints()[0].transform.position,Quaternion.identity);

        yield return new WaitForSeconds(waveConfiguration.GetTimeBetweenObstacles());
    }
}
