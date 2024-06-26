using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateDonut : MonoBehaviour
{
    [SerializeField] public GameObject donut;
    [SerializeField] public GameObject pos;
    //PickUpSystem pickUpSystem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(donut, pos.transform.position, Quaternion.identity);
        }
    }
}
