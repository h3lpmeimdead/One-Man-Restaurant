using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForPlacementScript : MonoBehaviour
{
    public GameObject Pos;
    public GameObject placeButton;
    public bool isInPlace;
    // Start is called before the first frame update
    void Start()
    {
        Pos = GetComponent<GameObject>();
        placeButton.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            placeButton.SetActive(true);
            isInPlace = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            placeButton.SetActive(false);
            isInPlace = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
