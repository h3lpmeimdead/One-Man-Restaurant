using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;
using UnityEngine.UIElements;

public class PickUpSystem : MonoBehaviour
{
    private GameObject holdItem;
    private UIScript uiScript;
    public bool canPick;
    private SpriteRenderer spriteRenderer;
    public Player player;
    private CheckForPlacementScript checkForPlacement;
    //private bool holdingItem;

    // Start is called before the first frame update
    void Start()
    {
        uiScript = GetComponent<UIScript>();
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
        Debug.Log("a");
        if (GameManager.Instance.currentActiveCat != player.catID)
        {
            return;
        }
        Debug.Log("b");
        holdItem.GetComponent<Collider2D>().enabled = true;
        holdItem.transform.SetParent(null);
        holdItem = null;
        canPick = true;
        //holdingItem = false;
        spriteRenderer.sortingOrder = -1;
    }


    public void PlaceObject()
    {
        if (checkForPlacement.isInPlace == true && canPick == false)
        {
            if (GameManager.Instance.currentActiveCat != player.catID)
            {
                return;
            }
            holdItem.transform.position = checkForPlacement.Pos.transform.position;
        }
    }
}
