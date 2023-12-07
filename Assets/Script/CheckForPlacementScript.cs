using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForPlacementScript : MonoBehaviour
{
    public GameObject Pos;
    public GameObject placeButton;
    //public bool isInPlace;
    //public Transform pointPos;
    

    // Start is called before the first frame update
    void Start()
    {
        //Pos = GetComponent<GameObject>();
        placeButton.SetActive(false);
        //pointPos = Pos.transform; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //isInPlace = true;
            placeButton.SetActive(true);
            //Debug.Log(isInPlace);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            placeButton.SetActive(false);
            //isInPlace = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
