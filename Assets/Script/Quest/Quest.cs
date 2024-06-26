using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public enum IngredientName
{
    Dish,
    Bowl,
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

public enum DishName
{
    BaconDish,
    BreadDish,
    BurgerDish,
    DonutDish,
    FrenchfriesDish,
    FriedEggDish,
    GarlicBreadDish,
    HotdogDish,
    SalmonDish,
    SandwichDish,
    SteakDish,
    IceCreamDish
}

public class Quest : MonoBehaviour
{

    public int totalQuest;
    public int currentQuest;
    float spawnRecipeTimer;
    public TMP_Text questText;
    public GameObject nextLevelMenu, nextLevelMenu1, nextLevelMenu2, nextLevelMenu3;
    Timer timer;
    public bool questInComplete = false;
    public Order currentOrder;

    public void DeliverItem(Dish deliveredItem)
    {
        if (currentOrder != null)
        {
            //if (currentOrder.orderedDish.ID == deliveredItem.ID)
            //{
                QuestComplete(currentOrder);
                
            //}
            //else
            //{
            //    QuestIncomplete();
            //}
        }
    }

    private void Start()
    {
        timer = FindObjectOfType<Timer>();  
        nextLevelMenu.SetActive(false);
        nextLevelMenu1.SetActive(false);
        nextLevelMenu2.SetActive(false);
        nextLevelMenu3.SetActive(false);
        ResetQuest();
    }

    private void Update()
    {
        ServeCustomer();
    }

    public void ServeCustomer()
    {

        UpdateQuestText();
        if (currentQuest >= totalQuest && timer.remainingTime > 0)
        {
            nextLevelMenu3.SetActive(true);
        }
        if(timer.remainingTime == 0 && (currentQuest < totalQuest && currentQuest >= 20))
        {
            nextLevelMenu2.SetActive(true);
        }
        if(timer.remainingTime == 0 && (currentQuest < 20 && currentQuest >= 10))
        {
            nextLevelMenu1.SetActive(true);
        }
        if(timer.remainingTime == 0 && (currentQuest < 10 && currentQuest >= 5))
        {
            nextLevelMenu.SetActive(true);
        }
    }

    void ResetQuest()
    {
        currentQuest = 0;
        UpdateQuestText();
    }

    public void QuestComplete(Order obj)
    {
        //if the same item 
        currentQuest++;
        Destroy(obj);
    }

    public void QuestIncomplete()
    {
        //if different item
        questInComplete = true;
    }
    
    public void UpdateQuestText()
    {
        questText.text = "Customer Served: " + currentQuest + "/" + totalQuest;
    }
}
