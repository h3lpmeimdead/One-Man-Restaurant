using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Recipe")]
public class RecipeSO : ScriptableObject
{
    public List<IngredientName> ingredientsList;
    public Sprite resultItemSprite;
}





