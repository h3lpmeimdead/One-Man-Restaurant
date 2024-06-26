using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePlate : MonoBehaviour
{
    [SerializeField] public GameObject plate;
    [SerializeField] public GameObject pos;
    //PickUpSystem pickUpSystem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(plate, pos.transform.position, Quaternion.identity);
        }
    }
}
