using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBun : MonoBehaviour
{
    [SerializeField] public GameObject bun;
    [SerializeField] public GameObject pos;
    //PickUpSystem pickUpSystem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(bun, pos.transform.position, Quaternion.identity);
        }
    }
}
