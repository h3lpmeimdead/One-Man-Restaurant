using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private RecipeSO[] m_RecipeData;

    [SerializeField] private SpriteRenderer m_Renderer;

    [SerializeField] List<int> listIngredient = new List<int>();

    public void AddIngredient(int id)
    {
        listIngredient.Add(id);
        foreach(RecipeSO recipe in m_RecipeData)
        {
            if (recipe.IsCompleted(listIngredient))
            {
                Debug.Log("Completed");
                m_Renderer.sprite = recipe.resultItem.resultSprite;
                return;
            }
        }
        Debug.Log("Failed");
    }

    private void RemoveIngredients()
    {
        listIngredient = new List<int>();
    }
}
