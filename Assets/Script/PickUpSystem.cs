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

    private void OnTriggerEnter2D(Collider2D collision) //when player enter the collision box
    {
        if(collision.CompareTag("Interactable")) //if the item has the tag "Interactable"
        {
            uiScript.ShowText("E to pick up");
            if(Input.GetKeyDown(KeyCode.E))
            {

            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickUpItem()
    {

    }

    public void DropItem()
    {

    }
}
