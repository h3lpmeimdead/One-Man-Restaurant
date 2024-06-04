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

//    public bool IsCompleted(List<int> inputs)
//    {
//        if (inputs.Count != ingredientsArray.Count)
//        {
//            Debug.Log("a");
//            return false;
//        }

//        inputs.Sort();
//        ingredientsArray.OrderBy(x => x.id);
//        Debug.Log(ingredientsArray.OrderBy(x => x.id));
//        for (int i = 0; i < inputs.Count; i++)
//        {
//            if (ingredientsArray[i].id != inputs[i])
//            {
//                return false;
//                Debug.Log("c");
//            }
//        }

//        return true;
//    }
}

//[Serializable]
//public class Ingredients
//{
//    public int id;
//    public float amount;
//}



