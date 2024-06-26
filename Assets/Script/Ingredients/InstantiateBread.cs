using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBread : MonoBehaviour
{
    [SerializeField] public GameObject bread;
    [SerializeField] public GameObject pos;
    //PickUpSystem pickUpSystem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(bread, pos.transform.position, Quaternion.identity);
        }
    }
}
