using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ProcessRecipe : MonoBehaviour
{
    public Recipe[] recipes;
    

    public void checkRecipe()
    {
        string objName = "3";
        int id = 3;

        if (objName.Equals(id.ToString()))
        {

        }
    }

}   

[Serializable]
public class Recipe
{
    public ScriptableObject recipe;
}



