using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    public GameObject explotionPrefab;

    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private Transform[] spawnPositions;

    [SerializeField]
    private float timeToSpawn;

    [SerializeField]
    public Transform[] BombLines;
    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToSpawn);
            Vector2 spawnCoords = spawnPositions[Random.Range(0, 2)].position + new Vector3(0, Random.Range(-14, 14));
            Instantiate(enemyPrefab, spawnCoords, Quaternion.identity);
        }
    }
}
