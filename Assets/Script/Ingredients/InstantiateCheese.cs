using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCheese : MonoBehaviour
{
    [SerializeField] public GameObject cheese;
    [SerializeField] public GameObject pos;
    //PickUpSystem pickUpSystem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(cheese, pos.transform.position, Quaternion.identity);
        }
    }
}
