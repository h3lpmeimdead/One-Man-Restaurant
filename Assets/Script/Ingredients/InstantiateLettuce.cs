using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateLettuce : MonoBehaviour
{
    [SerializeField] public GameObject lettuce;
    [SerializeField] public GameObject pos;
    //PickUpSystem pickUpSystem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(lettuce, pos.transform.position, Quaternion.identity);
        }
    }
}
