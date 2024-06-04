using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum IngredientName
{
    Dish,
    Bowl,
    Burger,
    Sandwich,
    Donut,
    HotDog,
    FriedEgg,
    Steak,
    Bacon,
    Frenchfries,
    GarlicBread,
    Salmon,
    Bread,
    RawMeat,
    Tomato,
    Sausage,
    Egg,
    SpringOnion,
    RawBacon,
    Bun,
    Cheese,
    Chocolate,
    Potato,
    Garlic,
    RawSalmon,
    RawDonut,
    Ketchup,
    Lettuce
}


public class RecipeManager : MonoBehaviour
{
    public static RecipeManager intstance;
    public List<RecipeSO> recipeList = new List<RecipeSO>();
    

    public void Awake()
    {
        intstance = this; 
    }

    public bool CheckRecipe(List<IngredientName> ingredientList, Transform holder)
    {
        //Debug.Log("a");
        bool isComplete = true;
        for(int i = 0; i < recipeList.Count; i++)
        {
            if (recipeList[i].ingredientsList.Count != ingredientList.Count)
            {
                continue;
            }
            for(int j = 0; j < ingredientList.Count; j++)
            {
                if(ingredientList[j] == recipeList[i].ingredientsList[j])
                {
                    isComplete = true;
                    continue;
                }
                isComplete = false;
                break;
            }

            if (isComplete)
            {
                Debug.Log("true");
                GameObject obj = new GameObject("Dish", typeof(PickableObject), typeof(BoxCollider2D), typeof(SpriteRenderer));
                obj.GetComponent<BoxCollider2D>().isTrigger = true;
                obj.GetComponent<SpriteRenderer>().sprite = recipeList[i].resultItemSprite;
                obj.transform.position = holder.transform.position;
                return true;
            }

        }
        return false;
    }
        
}
