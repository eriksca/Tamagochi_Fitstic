using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFood : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] FoodData _foodStats;
    UIManager uiManager;
    
   
    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        uiManager.OpenFoodStatsPanel();
        SendFoodData();
       
        uiManager.foodStatsText.text = $"Carbs: {_foodStats.CarboAmount}\n" +
            $"Fat: {_foodStats.FatAmount} \nProtein: {_foodStats.ProteinAmount}";
    }
    private void OnTriggerExit(Collider other)
    {
        uiManager.CloseFoodStatsPanel();
        ResetFoodData();
       
    }

    private void SendFoodData()
    {
        GameManager.foodStats = _foodStats;
    }
    private void ResetFoodData()
    {
        GameManager.foodStats = null;
    }
    
}
