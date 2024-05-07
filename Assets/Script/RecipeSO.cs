using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Recipe")]
public class RecipeSO : ScriptableObject
{
    public Ingredients[] ingredientsArray;
    public ResultItem resultItem;

    public bool IsCompleted(Ingredients[] inputs)
    {
        if (inputs.Length != ingredientsArray.Length)
            return false;

        Array.Sort(inputs);
        Array.Sort(ingredientsArray);

        for (int i = 0; i < inputs.Length; i++)
        {
            if (ingredientsArray[i] != inputs[i])
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