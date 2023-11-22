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
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        uiScript = GetComponent<UIScript>();
        canPick = true;
        player = GetComponent<Player>();
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
        if (GameManager.Instance.currentActiveCat != player.catID)
            return;
        holdItem.GetComponent<Collider2D>().enabled = true;
        holdItem.transform.SetParent(null);
        holdItem = null;
        canPick = true;
    }

    public void checkForCharacter()
    {

    }
}
