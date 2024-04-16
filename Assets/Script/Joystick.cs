using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour
{
    //string gameObjectname;
    public GameObject joystickBG;
    public GameObject joystick;
    public Vector2 joystickVec;
    public Vector2 joystickTouchPos;
    public Vector2 joystickOriginalPos;
    public float joystickRadius;
    //public SpriteRenderer spriteRenderer;
    //public Animator animator;
    //public float angle;
    // Start is called before the first frame update
    void Start()
    {
        joystickOriginalPos = joystickBG.transform.position;
        joystickRadius = joystickBG.GetComponent<RectTransform>().sizeDelta.y / 4; 
        //animator = FindObjectOfType<Animator>();
        //spriteRenderer = FindObjectOfType<SpriteRenderer>();
        //gameObjectname = gameObject.name;
        //Debug.Log(gameObjectname);
    }

    public void PointerDown()
    {
        joystick.transform.position = Input.mousePosition;
        joystickBG.transform.position = Input.mousePosition;
        joystickTouchPos = Input.mousePosition;
    }

    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector2 dragPos = pointerEventData.position;
        joystickVec = (dragPos - joystickTouchPos).normalized;

        float joystickDist = Vector2.Distance(dragPos, joystickTouchPos);
        if(joystickDist < joystickRadius) 
        {
            joystick.transform.position = joystickTouchPos + joystickVec * joystickDist;
        }
        else
        {
            joystick.transform.position = joystickTouchPos + joystickVec * joystickRadius;
        }
        
    }

    public void PointerUp()
    {
        joystickVec = Vector2.zero;
        joystick.transform.position = joystickOriginalPos;
        joystickBG.transform.position = joystickOriginalPos;
    }

    // Update is called once per frame
    void Update()
    {
        //if (joystickVec.x < 0)
        //{
        //    animator.SetTrigger("move");
        //    spriteRenderer.flipX = true;
        //    Debug.Log("flipped");
        //}
        //if (joystickVec.x > 0)
        //{
        //    animator.SetTrigger("move");
        //    spriteRenderer.flipX = false;
        //    Debug.Log("flippeda");
        //}
        
    }
}
