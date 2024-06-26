using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePotato : MonoBehaviour
{
    [SerializeField] public GameObject potato;
    [SerializeField] public GameObject pos;
    //PickUpSystem pickUpSystem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(potato, pos.transform.position, Quaternion.identity);
        }
    }
}
