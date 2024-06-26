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
    public Dish[] possibleDishOrder;
    Order order;
    PickUpSystem pickUpSystem;
    //private List<int> occupiedSpawnPoints = new List<int>(); //list to keep track occupied spawn points
    //public float maxNumberOfCustomers = 3;
    //public float currentCustomers = 0;

    //Quest quest;

    private void Start()
    {
        //quest = FindObjectOfType<Quest>();
        order = FindObjectOfType<Order>();
        pickUpSystem = FindObjectOfType<PickUpSystem>();
    }

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

    public void SpawnCustomer()
    {
        //if (currentCustomers >= maxNumberOfCustomers)
        //    return;
        //if(currentCustomers < maxNumberOfCustomers)
        //{
        int targetIndex = Random.Range(0, spawnPoints.Count);
        Vector3 spawnPos = spawnPoints[targetIndex].position;
        Instantiate(customerPrefab[Random.Range(0, customerPrefab.Length)], spawnPos, Quaternion.identity);
        usedPoints.Add(spawnPoints[targetIndex]);
        spawnPoints.RemoveAt(targetIndex);
        if(pickUpSystem.trianglePressed == true)
        {

        }
        if(order != null && possibleDishOrder.Length > 0)
        {
            Dish randomOrder = possibleDishOrder[Random.Range(0, possibleDishOrder.Length)];
            order.AssignOrder(randomOrder);
            Debug.Log(randomOrder);
        }
        //}
    }

    //public void DespawnCustomer()
    //{
    //    if(quest.questInComplete == true)
    //    {
    //        currentCustomers--;
    //    }
    //}
}
