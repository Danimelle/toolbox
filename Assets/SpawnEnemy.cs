using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform spawnPoint;

    [SerializeField] GameObject[] spawnPoints;



    [SerializeField] float minXposition;
    [SerializeField] float maxXposition;
    [SerializeField] float minYposition;
    [SerializeField] float maxYposition;
    [SerializeField] GameManager gameManager;
    private float xPosition;
    private float yPosition;
    private Vector3 spawnPos;
    private int spawnIndex;
    private GameObject activeSpawner;



    // public void ButtonPressed()
    // {
    //     Debug.Log("Enemy spawned");

    //     Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    // }

    public void RandomInAreaSpawn()
    {
        spawnPos = new Vector3(GetRandomSpawnX(), GetRandomSpawnY(), 0);
        GameObject spawnedBallon = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

        Ballon ballonScript = spawnedBallon.GetComponent<Ballon>();
        gameManager.AddBallon(ballonScript);
    }

    // public void RandomFromList()
    // {
    //     spawnIndex = Random.Range(0, spawnPoints.Length);
    //     activeSpawner = spawnPoints[spawnIndex];
    //     Instantiate(enemyPrefab, activeSpawner.transform.position, Quaternion.identity);
    // }



    private float GetRandomSpawnX()
    {
        xPosition = Random.Range(minXposition, maxXposition);
        return xPosition;
    }

    private float GetRandomSpawnY()
    {
        yPosition = Random.Range(minYposition, maxYposition);
        return yPosition;
    }
}
