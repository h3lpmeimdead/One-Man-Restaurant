using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;

public class PickUpSystem : MonoBehaviour
{
    private GameObject holdItem;
    private UIScript uiScript;
    private bool canPick;
    private SpriteRenderer spriteRenderer;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        uiScript = GetComponent<UIScript>();
        canPick = true;
        player = GetComponent<Player>();
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
        spriteRenderer.sortingOrder = -1;
    }
}
