using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Recipe : MonoBehaviour
{
    [Serializable]
    private class FoodRecipe
    {
        public ScriptableObject foodRecipe;
    }

    [SerializeField] private FoodRecipe[] FoodRecipesArray;
}
