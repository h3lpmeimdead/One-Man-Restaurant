using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateTomato : MonoBehaviour
{
    [SerializeField] public GameObject tomato;
    [SerializeField] public GameObject pos;
    //PickUpSystem pickUpSystem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(tomato, pos.transform.position, Quaternion.identity);
        }
    }
}
