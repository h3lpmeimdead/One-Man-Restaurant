using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEgg : MonoBehaviour
{
    [SerializeField] public GameObject egg;
    [SerializeField] public GameObject pos;
    //PickUpSystem pickUpSystem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(egg, pos.transform.position, Quaternion.identity);
        }
    }
}
