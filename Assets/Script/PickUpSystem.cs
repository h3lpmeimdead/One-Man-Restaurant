using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;
using UnityEngine.UIElements;

public class PickUpSystem : MonoBehaviour
{
    public GameObject holdItem;
    public bool canPick;
    private SpriteRenderer spriteRenderer;
    public Player player;
    private CheckForPlacementScript checkForPlacement;
    GameObject placedItem;
    public bool canDelete;
    public IPlaceable placeable;
    public IPickable pickable;

    // Start is called before the first frame update
    void Start()
    {
        canPick = true;
        player = GetComponent<Player>();
        checkForPlacement = GetComponent<CheckForPlacementScript>();
        //Debug.Log(player);
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
                canDelete = true;
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
            canDelete = false;
            spriteRenderer.sortingOrder = -1;
        }
    }


    public void PlaceObject()
    {
        if (GameManager.Instance.currentActiveCat != player.catID)
        {
            return;
        }
        placeable.OnPlace(holdItem);
        holdItem.transform.SetParent(null);
        canPick = true;
        holdItem = null;
        spriteRenderer.sortingOrder = 0;
    }

    public void PickFromTable()
    {
        if (GameManager.Instance.currentActiveCat != player.catID)
        {
            return;
        }
        pickable.Pickable(holdItem);
        holdItem.transform.SetParent(transform);
        spriteRenderer.sortingOrder = 1;
        canPick = false;
        canDelete = true;
        holdItem.GetComponent<Collider2D>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<IPlaceable>(out var place))
        {
            placeable = place;
        }
        if(collision.TryGetComponent<IPickable>(out var pick))
        {
            pickable = pick;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IPlaceable>(out var place))
        {
            placeable = null;
        }
        if (collision.TryGetComponent<IPickable>(out var pick))
        {
            pickable = null;
        }
    }

    public void DeleteObject()
    {
        if (canPick == false && player.CompareTag("Trash"))
        {
            //Debug.Log("trash");
            if (GameManager.Instance.currentActiveCat != player.catID)
            {
                return;
            }
            holdItem.GetComponent<Collider2D>().enabled = true;
            holdItem.transform.SetParent(null);
            Destroy(holdItem);
            canPick = true;
            canDelete = false;
        }
    }
    
}
