using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchingCharacter : MonoBehaviour
{
    public Player Chef;
    public Player Waiter;
    public Player FoodManager;
    public bool WaiterActive = true;
    public bool FoodManagerActive = false;
    public bool ChefActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SwitchToWaiter()
    {
        if(WaiterActive == false)
        {
            Waiter.enabled = true;
            Chef.enabled = false;
            FoodManager.enabled = false;
            WaiterActive = true;
            ChefActive = false;
            FoodManagerActive = false;
        }
    }
    public void SwitchToFoodManager()
    {
        if (FoodManagerActive == false)
        {
            Waiter.enabled = false;
            Chef.enabled = false;
            FoodManager.enabled = true;
            WaiterActive = false;
            ChefActive = false;
            FoodManagerActive = true;
        }
    }
    
    public void SwitchToChef()
    {
        if (ChefActive == false)
        {
            Waiter.enabled = false;
            Chef.enabled = true;
            FoodManager.enabled = false;
            WaiterActive = false;
            ChefActive = true;
            FoodManagerActive = false;
        }
    }
}
