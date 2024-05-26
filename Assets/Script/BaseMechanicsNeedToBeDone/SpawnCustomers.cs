using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCustomers : MonoBehaviour
{
    public GameObject customerPrefab;
    public Transform[] spawnPoints;
    public float spawnInterval;
    public float totalTime;
    public float numberOfCustomers;
    public float currentTime;

    private void Update()
    {
        if (currentTime <= totalTime)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= spawnInterval)
            {
                SpawnCustomer();
                currentTime = 0f;
            }
        }
        else
        {
            // Time's up, stop spawning
            enabled = false;
        }
    }

    void SpawnCustomer()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Vector3 spawnPos = spawnPoints[randomIndex].position;
        Instantiate(customerPrefab, spawnPos, Quaternion.identity);
    }
}
