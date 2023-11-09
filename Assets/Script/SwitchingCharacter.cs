using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.Notifications.Android;

public class SwitchingCharacter : MonoBehaviour
{
    public CinemachineVirtualCamera vcCamera;
    public GameObject waiter, foodManager, chef;
    //[SerializeField] Player player;
    
    //private float shakeTime = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        waiter = GameObject.Find("Waiter");
        foodManager = GameObject.Find("FoodManager");
        chef = GameObject.Find("Chef");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SwitchToWaiter()
    {
        vcCamera.Follow = waiter.transform;
        waiter.GetComponent<Player>().enabled = true;
        foodManager.GetComponent<Player>().enabled = false;
        chef.GetComponent<Player>().enabled = false;
    }
    public void SwitchToFoodManager()
    {
        vcCamera.Follow = foodManager.transform;
        waiter.GetComponent<Player>().enabled = false;
        foodManager.GetComponent<Player>().enabled = true;
        chef.GetComponent<Player>().enabled = false;
    }
    
    public void SwitchToChef()
    {
        vcCamera.Follow = chef.transform;
        //player.ShakingCam();
        waiter.GetComponent<Player>().enabled = false;
        foodManager.GetComponent<Player>().enabled = false;
        chef.GetComponent<Player>().enabled = true;
    }
}
