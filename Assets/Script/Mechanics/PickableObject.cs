using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickableObject : MonoBehaviour, IPickable, IPlaceable
{
    public string text;
    [SerializeField] public int id;
    

    private void Awake()
    {
        
    }
    public void OnPlace(Vector2 targetPosition)
    {
        GetComponent<Collider2D>().enabled = true;
        transform.parent = null;
        transform.position = targetPosition;
    }

    public void Pickable(Transform go)
    {
        transform.parent = go;
        transform.localPosition = Vector3.zero;
        GetComponent<Collider2D>().enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InGameUI pop = GameObject.FindGameObjectWithTag("GameManager").GetComponent<InGameUI>();
            pop.popUp(text);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InGameUI pop = GameObject.FindGameObjectWithTag("GameManager").GetComponent<InGameUI>();
            pop.animator.SetTrigger("Close");
        }
    }

}
