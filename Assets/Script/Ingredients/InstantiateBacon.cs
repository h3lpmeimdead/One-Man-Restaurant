using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBacon : MonoBehaviour
{
    [SerializeField] public GameObject bacon;
    [SerializeField] public GameObject pos;
    //PickUpSystem pickUpSystem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("player");
            Instantiate(bacon, pos.transform.position, Quaternion.identity);
            //pickUpSystem.GetComponent<PickUpSystem>().Triangle();
            //if(pickUpSystem.trianglePressed == true)
            //{
            //    Debug.Log(pickUpSystem.trianglePressed);
            //    pickUpSystem.trianglePressed = false;
            //}
        }
    }
}
