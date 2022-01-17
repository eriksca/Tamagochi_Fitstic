using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(FloatingAnimation))]
//[RequireComponent(typeof(TryAnnimation))]
public class MyFood : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] FoodData _foodStats;
    UIManager uiManager;
    public static bool isFoodStatsDisabled;
    
   
    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
        isFoodStatsDisabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        uiManager.OpenFoodStatsPanel();
        isFoodStatsDisabled = false; 
        SendFoodData();
        
        uiManager.foodStatsText.text = $"Carbs: {_foodStats.CarboAmount}\n" +
            $"Fat: {_foodStats.FatAmount} \nProtein: {_foodStats.ProteinAmount}";
        uiManager.foodImg.sprite = _foodStats.FoodTexture;
        
    }
    private void OnTriggerExit(Collider other)
    {
        uiManager.CloseFoodStatsPanel();
        ResetFoodData();
       
    }
    private void OnDisable()
    {
        //uiManager.CloseFoodStatsPanel(); ---> da errori perchè tutti i food cercano di disabilitarlo quando si stoppa la scena
        //GameManager.foodStats = null;
        ResetFoodData();
        GameManager.closestFood = null;
        
    }

    private void SendFoodData()
    {
        GameManager.foodStats = _foodStats;
        GameManager.closestFood = this.gameObject;
    }
    private void ResetFoodData()
    {
        GameManager.foodStats = null;
    }
    
}
