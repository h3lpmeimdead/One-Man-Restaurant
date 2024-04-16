using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using UnityEngine.UIElements;

/*
 * Player animation 4 dir
 * raycast for player
 * ui manager for canvas
 * rewrite logic for placing button
 */

public class PickUpSystem : MonoBehaviour
{
    public GameObject holdItem;
    public bool canPick;
    private SpriteRenderer spriteRenderer;
    Player player;
    private CheckForPlacementScript checkForPlacement;
    GameObject placedItem;
    public bool canDelete;
    //public IPlaceable placeable;
    //public IPickable pickable;
    public float angle;
    public Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        canPick = true;
        player = GetComponent<Player>();
        //checkForPlacement = GetComponent<CheckForPlacementScript>();
        
    }
    // Update is called once per frame
    void Update()
    {
        // using vector3,right to find angle between joystick position and vector3.right
        //angle = Vector3.Angle(joystick.joystick.transform.position, Vector3.right);
        //Debug.Log(angle);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.right, 1);

        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
        }

        Debug.DrawRay(transform.position, Vector3.right, Color.red);
        
    }

    public void PickUpItem()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.5f);
        foreach(Collider2D collider in colliders)
        {
            //if(collider.CompareTag("Interactable") && canPick == true)
            //{
            //    if (GameManager.Instance.currentActiveCat != player.catID)
            //    {
            //        return;
            //    }
            //    spriteRenderer = collider.GetComponent<SpriteRenderer>();
            //    spriteRenderer.sortingOrder = 1;
            //    holdItem = collider.gameObject;
            //    holdItem.transform.SetParent(transform); // set the object to be the child of the player
            //    holdItem.transform.localPosition = Vector3.zero;
            //    holdItem.GetComponent<Collider2D>().enabled = false; // set the collider of the object to false
            //    canPick = false;
            //    canDelete = true;
            //    break;
            //}

            if(collider.TryGetComponent<IPickable>(out var pickable) && canPick == true)
            {
                if (GameManager.Instance.currentActiveCat != player.catID)
                {
                    return;
                }

                spriteRenderer = collider.GetComponent<SpriteRenderer>();
                spriteRenderer.sortingOrder = 1;
                holdItem = collider.gameObject;
                pickable.Pickable(transform);
                canPick = false;
                canDelete = true;
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
            //holdItem.GetComponent<Collider2D>().enabled = true;
            //holdItem.transform.SetParent(null);
            holdItem.GetComponent<IPlaceable>().OnPlace(transform.position);
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

        if(checkForPlacement != null)
        {
            holdItem.GetComponent<IPlaceable>().OnPlace(checkForPlacement.Pos.transform.position);
            holdItem.transform.SetParent(null);
            canPick = true;
            holdItem = null;
            spriteRenderer.sortingOrder = 0;
        }
    }

    //public void PickFromTable()
    //{
    //    if (GameManager.Instance.currentActiveCat != player.catID)
    //    {
    //        return;
    //    }
    //    pickable.Pickable(holdItem);
    //    holdItem.transform.SetParent(transform);
    //    spriteRenderer.sortingOrder = 1;
    //    canPick = false;
    //    canDelete = true;
    //    holdItem.GetComponent<Collider2D>().enabled = false;
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.TryGetComponent<IPlaceable>(out var place))
        //{
        //    placeable = place;
        //}
        //if (collision.TryGetComponent<IPickable>(out var pick))
        //{
        //    pickable = pick;
        //}

        if(collision.GetComponent<CheckForPlacementScript>() != null)
        {
            checkForPlacement = collision.GetComponent<CheckForPlacementScript>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (collision.TryGetComponent<IPlaceable>(out var place))
        //{
        //    placeable = null;
        //}
        //if (collision.TryGetComponent<IPickable>(out var pick))
        //{
        //    pickable = null;
        //}
        if (collision.GetComponent<CheckForPlacementScript>() != null)
        {
            checkForPlacement = null;
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
