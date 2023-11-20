using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //for using the UI

public class UIScript : MonoBehaviour
{
    public Text interactText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowText(string message)
    {
        interactText.text = message; //UI text = interactText
        interactText.enabled = true; //turn on text
    }

    public void HideText()
    {
        interactText.enabled = false; //turn off text
    }
}
