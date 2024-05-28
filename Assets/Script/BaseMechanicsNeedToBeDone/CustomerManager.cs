using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public List<RecipeSO> availableRecipes;
    public float requestInterval = 10f;
    private float timer;

    void Start()
    {
        timer = requestInterval;
    }

    void Update()
    {
        GenerateCustomerRequest();
        //timer -= Time.deltaTime;
        //if (timer <= 0f)
        //{
        //    timer = requestInterval;
        //}
    }

    void GenerateCustomerRequest()
    {
        int randomIndex = Random.Range(0, availableRecipes.Count);
        RecipeSO requestedRecipe = availableRecipes[randomIndex];
        DisplayCustomerRequest(requestedRecipe);
    }

    void DisplayCustomerRequest(RecipeSO recipe)
    {
        //Debug.Log("Customer requests: " + recipe.recipeName);
    }

    
}
