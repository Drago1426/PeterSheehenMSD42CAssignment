using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigList;

    [SerializeField] bool looping = false;

    int startingWave = 0;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnAllObjectsInWave(WaveConfig waveToSpawn)
    {
        for (int objectCount = 1; objectCount <= waveToSpawn.GetNumberOfObstacles(); objectCount++)
        {
            var newEnemy = Instantiate(
                            waveToSpawn.GetEnemyPrefab(),
                            waveToSpawn.GetWaypoints()[0].transform.position,
                            Quaternion.identity);

            newEnemy.GetComponent<ObstaclePathing>().SetWaveConfig(waveToSpawn);

            yield return new WaitForSeconds(waveToSpawn.GetTimeBetweenSpawns());
        }
    }

    private IEnumerator SpawnAllWaves()
    {
        foreach(WaveConfig currentWave in waveConfigList)
        {
            yield return StartCoroutine(SpawnAllObjectsInWave(currentWave));
        }
    }
}
