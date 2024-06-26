using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateSausage : MonoBehaviour
{
    [SerializeField] public GameObject sausage;
    [SerializeField] public GameObject pos;
    //PickUpSystem pickUpSystem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(sausage, pos.transform.position, Quaternion.identity);
        }
    }
}
