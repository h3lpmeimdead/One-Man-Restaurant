using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateSpringOnion : MonoBehaviour
{
    [SerializeField] public GameObject onion;
    [SerializeField] public GameObject pos;
    //PickUpSystem pickUpSystem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(onion, pos.transform.position, Quaternion.identity);
        }
    }
}
