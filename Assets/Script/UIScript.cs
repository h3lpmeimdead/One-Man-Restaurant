using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //for using the UI
using TMPro;

public class UIScript : MonoBehaviour
{
    [SerializeField] public GameObject creditui;
    [SerializeField] private GameObject panel;
    [SerializeField] public Animator animator;
    [SerializeField] private TMP_Text popUptext;
    
    public void popUp(string text)
    {
        panel.SetActive(true);
        popUptext.text = text;
        animator.SetTrigger("PopUp");
    }
}
