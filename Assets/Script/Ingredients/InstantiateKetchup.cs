using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateKetchup : MonoBehaviour
{
    [SerializeField] public GameObject ketchup;
    [SerializeField] public GameObject pos;
    //PickUpSystem pickUpSystem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Instantiate(ketchup, pos.transform.position, Quaternion.identity);
        }
    }
}
