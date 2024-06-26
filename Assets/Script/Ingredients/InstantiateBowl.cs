using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBowl : MonoBehaviour
{
    [SerializeField] public GameObject bowl;
    [SerializeField] public GameObject pos;
    //PickUpSystem pickUpSystem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(bowl, pos.transform.position, Quaternion.identity);
        }
    }
}
