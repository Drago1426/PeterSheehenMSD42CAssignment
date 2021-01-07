using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;

    [SerializeField] GameObject pathPrefab;

    [SerializeField] float timeBetweenSpawns = 0.5f;

    [SerializeField] float spawnRandomFactor = 0.3f;

    [SerializeField] int numberOfObstacles = 5;

    [SerializeField] float objectMoveSpeed = 2f;

    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }

    public List<Transform> GetWaypoints()
    {
        var waveWayPoints = new List<Transform>();

        foreach (Transform child in pathPrefab.transform)
        {
            waveWayPoints.Add(child);
        }

        return waveWayPoints;
    }

    public GameObject GetPathPrefab()
    {
        return pathPrefab;
    }

    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float GetSpawnRandomFactor()
    {
        return spawnRandomFactor;
    }

    public int GetNumberOfObstacles()
    {
        return numberOfObstacles;
    }

    public float GetObjectMoveSpeed()
    {
        return objectMoveSpeed;
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
