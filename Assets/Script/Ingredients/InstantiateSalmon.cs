using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateSalmon : MonoBehaviour
{
    [SerializeField] public GameObject salmon;
    [SerializeField] public GameObject pos;
    //PickUpSystem pickUpSystem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(salmon, pos.transform.position, Quaternion.identity);
        }
    }
}
