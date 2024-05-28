using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerOrder : MonoBehaviour
{
    public string customerName;
    public void Interact()
    {
        Debug.Log(customerName);
    }
}
