using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientsHolder : MonoBehaviour
{
    private List<IngredientName> ingredients = new List<IngredientName>();
    private List<GameObject> gameObjects = new List<GameObject>();

    public void Check()
    {
        //Debug.Log("check");
        if(RecipeManager.intstance.CheckRecipe(ingredients, transform.GetChild(0).transform))
        {
            ingredients.Clear();
            foreach(GameObject go in gameObjects)
            {
                Destroy(go);
            }
            gameObjects.Clear();
        }
    }

    public void AddIngredient(IngredientName name, GameObject obj)
    {
        ingredients.Add(name);
        gameObjects.Add(obj);
        Check();
    }
}
