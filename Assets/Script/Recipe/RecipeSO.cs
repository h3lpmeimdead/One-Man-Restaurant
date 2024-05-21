using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Recipe")]
public class RecipeSO : ScriptableObject
{
    public List<Ingredients> ingredientsArray;
    public ResultItem resultItem;

    public bool IsCompleted(List<int> inputs)
    {
        if (inputs.Count != ingredientsArray.Count)
            return false;

        inputs.Sort();
        ingredientsArray.OrderBy(x => x.id);

        for (int i = 0; i < inputs.Count; i++)
        {
            if (ingredientsArray[i].id != inputs[i])
                return false;
        }

        return true;
    }
}

[Serializable]
public class Ingredients
{
    public int id;
    public float amount;
}

[Serializable]
public class ResultItem
{
    public int id;
    public Sprite resultSprite;
}

