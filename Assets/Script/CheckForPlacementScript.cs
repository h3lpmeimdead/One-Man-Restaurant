using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForPlacementScript : MonoBehaviour, IPlaceable, IPickable
{
    public GameObject Pos;
    public GameObject placeButton;
    public GameObject placedObject;
    
    


    // Start is called before the first frame update
    void Start()
    {
        
        placeButton.SetActive(false);
        
    }


    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
            
    //        placeButton.SetActive(true);
            
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if(collision.gameObject.tag == "Player")
    //    {
    //        placeButton.SetActive(false);
            
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 GetPos()
    {
        Vector2 PlacingPos = Pos.transform.position; 
        return PlacingPos;
    }

    public void OnPlace(GameObject go)
    {
        go.transform.position = GetPos();
    }

    public void Pickable(GameObject go)
    {
        go.transform.localPosition = Vector3.zero;
    }

    public void HighlightObject()
    {
        if (placeButton.activeSelf)
            return;

        placeButton.SetActive(true);
    }
}
