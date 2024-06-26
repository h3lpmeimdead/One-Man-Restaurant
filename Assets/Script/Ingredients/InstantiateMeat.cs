using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateMeat : MonoBehaviour
{
    [SerializeField] public GameObject meat;
    [SerializeField] public GameObject pos;
    //PickUpSystem pickUpSystem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(meat, pos.transform.position, Quaternion.identity);
        }
    }
}
