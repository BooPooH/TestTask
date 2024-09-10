using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private Transform cubeParent;
    [SerializeField] private Transform player;

    [SerializeField] private float minSpawnDistance = 5f;
    [SerializeField] private float maxSpawnDistance = 10f;
    [SerializeField] private float spawnHeight = 15f;

    [SerializeField] private float minSpawnDelay = 0.5f;
    [SerializeField] private float maxSpawnDelay = 2f;    

    void Start()
    {
        StartCoroutine(SpawnCubs());
    }

    IEnumerator SpawnCubs()
    {
        while (true)
        {            
            float spawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(spawnDelay);

            Vector3 spawnPosition = GetRandomPositionAroundPlayer();
      
            Instantiate(cubePrefab, spawnPosition, Quaternion.identity, cubeParent);
        }
    }

    Vector3 GetRandomPositionAroundPlayer()
    {
        float distance = Random.Range(minSpawnDistance, maxSpawnDistance);

        float angle = Random.Range(0f, 360f);

        Vector3 spawnDirection = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));

        return player.position + spawnDirection * distance + Vector3.up * spawnHeight;
    }
}
