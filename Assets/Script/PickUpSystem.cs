using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;
using UnityEngine.UIElements;

public class PickUpSystem : MonoBehaviour
{
    private GameObject holdItem;
    //private UIScript uiScript;
    public bool canPick;
    private SpriteRenderer spriteRenderer;
    public Player player;
    private CheckForPlacementScript checkForPlacement;
    //private bool holdingItem;
    GameObject placedItem;

    // Start is called before the first frame update
    void Start()
    {
        //uiScript = GetComponent<UIScript>();
        canPick = true;
        player = GetComponent<Player>();
        checkForPlacement = GetComponent<CheckForPlacementScript>();
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickUpItem()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.5f);
        foreach(Collider2D collider in colliders)
        {
            if(collider.CompareTag("Interactable") && canPick == true)
            {
                if (GameManager.Instance.currentActiveCat != player.catID)
                {
                    return;
                }
                spriteRenderer = collider.GetComponent<SpriteRenderer>();
                spriteRenderer.sortingOrder = 1;
                holdItem = collider.gameObject;
                holdItem.transform.SetParent(transform); // set the object to be the child of the player
                holdItem.transform.localPosition = Vector3.zero;
                holdItem.GetComponent<Collider2D>().enabled = false; // set the collider of the object to false
                canPick = false;
                //holdingItem = true;
                break;
            }
        }
        
    }

    public void DropItem()
    {
        if (canPick == false)
        {
            //Debug.Log("a");
            if (GameManager.Instance.currentActiveCat != player.catID)
            {
                return;
            }
            //Debug.Log("b");
            holdItem.GetComponent<Collider2D>().enabled = true;
            holdItem.transform.SetParent(null);
            holdItem = null;
            canPick = true;
            spriteRenderer.sortingOrder = -1;
        }
    }


    public void PlaceObject()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up);
        if (canPick == false && hit.collider.CompareTag("Counter"))
        {
            if (GameManager.Instance.currentActiveCat != player.catID)
            {
                return;
            }
            Vector2 position = checkForPlacement.GetPos();
            placedItem = Instantiate(holdItem, position, Quaternion.identity);
            holdItem.GetComponent<Collider2D>().enabled = false;
            holdItem.transform.SetParent(null);
            holdItem = null;
            canPick = true;
            spriteRenderer.sortingOrder = 0;
        }
    }

    
}
