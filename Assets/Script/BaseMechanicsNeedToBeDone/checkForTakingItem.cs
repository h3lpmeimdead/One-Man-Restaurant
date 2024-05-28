using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkForTakingItem : MonoBehaviour
{
    GetItemFromStation getItemFromStation;

    private void Start()
    {
        getItemFromStation = FindObjectOfType<GetItemFromStation>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (getItemFromStation.isPressed == true)
            {
                //Instantiate
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

    }
}
