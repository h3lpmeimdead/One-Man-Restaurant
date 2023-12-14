using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour
{
    public string text;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            UIScript pop = GameObject.FindGameObjectWithTag("GameManager").GetComponent<UIScript>();
            pop.popUp(text);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UIScript pop = GameObject.FindGameObjectWithTag("GameManager").GetComponent<UIScript>();
            pop.animator.SetTrigger("Close");
        }
    }
}
