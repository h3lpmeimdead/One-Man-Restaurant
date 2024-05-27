using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCustomers : MonoBehaviour
{
    public GameObject[] customerPrefab; //array of customer prefabs
    public Transform[] spawnPoints; //array of spawn points
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
        for(int i = 0; i < numberOfCustomers; i++)
        {
            List<int> availableSpawnPoints = new List<int>();
            for(int j = 0; j < spawnPoints.Length; j++)
            {
                if(!occupiedSpawnPoints.Contains(j))
                {
                    availableSpawnPoints.Add(j);
                }
            }

            if(availableSpawnPoints.Count == 0)
            {
                return;
            }
            //randomly select an available spawnpoint
            int randomPrefabIndex = Random.Range(0, customerPrefab.Length);
            int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);
            Vector3 spawnPos = spawnPoints[randomSpawnPointIndex].position;
            Instantiate(customerPrefab[randomPrefabIndex], spawnPos, Quaternion.identity);

            occupiedSpawnPoints.Add(randomSpawnPointIndex);
        }
        
    }
}
