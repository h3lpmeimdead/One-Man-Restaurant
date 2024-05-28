using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using UnityEngine.UIElements;



public class PickUpSystem : MonoBehaviour
{
    public GameObject holdItem;
    public bool canPick;
    private SpriteRenderer spriteRenderer;
    Player player;
    private CheckForPlacementScript checkForPlacement;
    public bool canDelete;
    public Joystick joystick;
    public float radius;
    [SerializeField] public List<int> listIngredients = new List<int>();
    PickableObject pickableObject;

    // Start is called before the first frame update
    void Start()
    {
        canPick = true;
        player = GetComponent<Player>();
    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.right, 1);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
        }

        Debug.DrawRay(transform.position, Vector3.right, Color.red);
        Debug.DrawRay(transform.position, Vector3.up, Color.red);
    }

    public void PickUpItem()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        
        foreach(Collider2D collider in colliders)
        {
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
                pickableObject = collider.GetComponent<PickableObject>();
                
                Debug.Log(pickableObject.id);
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
            AddIngredient(pickableObject.id);
            checkForPlacement.GetComponent<ProcessRecipe>().checkIngredient();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<CheckForPlacementScript>() != null)
        {
            checkForPlacement = collision.GetComponent<CheckForPlacementScript>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<CheckForPlacementScript>() != null)
        {
            checkForPlacement = null;
        }
    }

    public void AddIngredient(int id)
    {
        listIngredients.Add(pickableObject.id);
    }
}
