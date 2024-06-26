using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    public Dish orderedDish;
    public Transform Pos;

    public void AssignOrder(Dish dish)
    {
        orderedDish = dish;
        Instantiate(dish, Pos.transform.position, Quaternion.identity);
        Debug.Log(orderedDish.itemName);
    }
}
