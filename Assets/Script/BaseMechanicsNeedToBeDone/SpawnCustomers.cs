using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCustomers : MonoBehaviour
{
    public GameObject[] customerPrefab; //array of customer prefabs
    public List<Transform> spawnPoints; //array of spawn points
    public List<Transform> usedPoints = new List<Transform>();
    public float spawnInterval; //time between spawns
    public float totalTime; //total time to spawn customers
    public float numberOfCustomers; //number of customers to spawn at each interval
    public float currentTime; 
    private List<int> occupiedSpawnPoints = new List<int>(); //list to keep track occupied spawn points
    public float maxNumberOfCustomers;
    
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
        int targetIndex = Random.Range(0, spawnPoints.Count);
        Vector3 spawnPos = spawnPoints[targetIndex].position;
        Instantiate(customerPrefab[Random.Range(0, customerPrefab.Length)], spawnPos, Quaternion.identity);
        usedPoints.Add(spawnPoints[targetIndex]);
        spawnPoints.RemoveAt(targetIndex);
    }
}
