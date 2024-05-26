using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ProcessRecipe : MonoBehaviour
{
    [SerializeField] private RecipeSO[] m_RecipeData;
    [SerializeField] private SpriteRenderer m_Renderer;
    PickUpSystem m_PickUpSystem;

    public void Start()
    {
        m_PickUpSystem = GetComponent<PickUpSystem>();
    }
    public void checkRecipe()
    {
        
    }

    public void AddIngredient(int id)
    {
        //listIngredient.Add(pickableObject.id);
    }
    public void checkIngredient()
    {
        foreach (RecipeSO recipe in m_RecipeData)
        {
            if (recipe.IsCompleted(m_PickUpSystem.listIngredients))
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
        m_PickUpSystem.listIngredients = new List<int>();
    }
}   



