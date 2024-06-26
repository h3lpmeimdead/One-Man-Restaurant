using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateChocolate : MonoBehaviour
{
    [SerializeField] public GameObject chocolate;
    [SerializeField] public GameObject pos;
    //PickUpSystem pickUpSystem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(chocolate, pos.transform.position, Quaternion.identity);
        }
    }
}
