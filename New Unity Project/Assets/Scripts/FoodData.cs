using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "food_data", menuName = "Food Data", order = 51)]
public class FoodData : ScriptableObject
{
    [SerializeField] private string foodName;
    [SerializeField] private float carboAmount;
    [SerializeField] private float fatAmount;
    [SerializeField] private float proteinAmount;
    [SerializeField] private Sprite foodTexture;
    
  

    public string FoodName { get { return foodName; } }

    public float CarboAmount { get { return carboAmount; } }
    public float FatAmount { get { return fatAmount; } }
    public float ProteinAmount { get { return proteinAmount; } }
    public Sprite FoodTexture { get { return foodTexture; } }


}
