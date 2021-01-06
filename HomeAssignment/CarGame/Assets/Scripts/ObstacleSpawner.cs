using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfiguration> waveConfigurationList;

    [SerializeField] bool looping = true;

    int startingWave = 0;

    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping);
    }

    
    void Update()
    {
        
    }

    //specified location
    private IEnumerator SpawnAllObstaclesInWave(WaveConfiguration waveToSpawn)
    {
        for (int obstacleCount = 1; obstacleCount <= waveToSpawn.GetNumberOfObstacles(); obstacleCount++)
        {
            //spawned enemy at waypoints
            var newObstacle = Instantiate(
            waveToSpawn.GetObstaclePrefab(), waveToSpawn.GetWaypoints()[0].transform.position, Quaternion.identity);

            //selected wave
            newObstacle.GetComponent<ObstaclePath>().SetWaveConfiguration(waveToSpawn);

            //timer between enemies
            yield return new WaitForSeconds(waveToSpawn.GetTimeBetweenObstacles());
        }
      
    }

    private IEnumerator SpawnAllWaves()
    {
        foreach(WaveConfiguration currentWave in waveConfigurationList)
        {
            yield return StartCoroutine(SpawnAllObstaclesInWave(currentWave));
        }
    }
}
