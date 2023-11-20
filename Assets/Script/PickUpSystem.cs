using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;

public class PickUpSystem : MonoBehaviour
{
    private GameObject holdItem;
    private UIScript uiScript;

    // Start is called before the first frame update
    void Start()
    {
        uiScript = GetComponent<UIScript>();   
    }

    //private void OnTriggerEnter2D(Collider2D collision) //when player enter the collision box
    //{
    //    if(collision.CompareTag("Interactable")) //if the item has the tag "Interactable"
    //    {
    //        //uiScript.ShowText("E to pick up");
    //        if(Input.GetKeyDown(KeyCode.E))
    //        {
    //            PickUpItem(collision.gameObject);
    //        }
    //    }
    //}
    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(holdItem == null && Input.GetKeyDown(KeyCode.E))
        {
            PickUpItem();
        }
        if(holdItem != null && Input.GetKeyDown(KeyCode.Q))
        {
            DropItem();
        }
    }

    public void PickUpItem()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.5f);
        foreach(Collider2D collider in colliders)
        {
            if(collider.CompareTag("Interactable"))
            {
                holdItem = collider.gameObject;
                holdItem.transform.SetParent(transform); // set the object to be the child of the player
                holdItem.transform.localPosition = Vector3.zero;
                holdItem.GetComponent<Collider2D>().enabled = false; // set the collider of the object to false
                break;
            }
        }
        
    }

    public void DropItem()
    {
        holdItem.GetComponent<Collider2D>().enabled = true;
        holdItem.transform.SetParent(null);
        holdItem = null;
    }
}
