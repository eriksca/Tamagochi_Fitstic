using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float _health;
    private float _happiness;
    private float _energy;
    private float _time;
   
    public int Health { get { return (int)_health; } }
    public int Happiness { get { return (int)_happiness; } }
    public int Energy { get { return (int)_energy; } }
    public int PlayTime { get { return (int)_time; } }
   
    /// <summary>
    /// timer variables utili per gestire le funzioni di decremento statistiche player durante l'esecuzione
    /// </summary>
    private float healthTimer =10f;
    private float happinessTimer=20f;
    private float energyTimer=30f;

    //amount of time before the player loses some of this stats
    [SerializeField] float maxHealthTimer;
    [SerializeField] float maxHappinessTimer;
    [SerializeField] float maxEnergyTimer;

    //manage if the player can move and can eat
    public static bool canPlay;
    //public static bool ;

    //food data passed by MyFood Class on trigger enter, on trigger exit the value returns to null
    public static FoodData foodStats = null;
    public static GameObject closestFood = null;
    private UIManager uIManager;
    
    
    /// <summary>
    /// fixed variables that I need to calculate how the food will affect my player stats
    /// </summary>

    private float carbsRefHappinessModifier = -3;
    private float carbsRefHealthModifier = +3;
    private float carbsRefWeight = 10;
   
    private float proteinsRefEnergyModifier = +3;
    float proteinsRefWeight = 10;
   
    private float fatsRefHappinessModifier = 2;
    private float fatsRefHealthModifier = -4;
    private float fatsRefWeight = 3;
    
    
    void Start()
    {
        _health = 50;
        _happiness = 50;
        _energy = 50;
        canPlay = true;
        foodStats = null;
        uIManager = GetComponent<UIManager>();
       // canEat = true;
 
    }

   
    void Update()
    {
        if (_health <= 0 || _happiness <= 0 || _energy <= 0)
        {
            canPlay = false;
            return;
        }
        ManagePlayerStats();
        
    }

    private void ManagePlayerStats()
    {
        _time += Time.deltaTime;
        if (_health >= 0 && healthTimer >= 0)
        {
            //Debug.Log(healthTimer);
            healthTimer -= Time.deltaTime;
            if (healthTimer <= 0)
            {
                ModifyHealth(-1);
                healthTimer = maxHealthTimer;
            }
        }
        if (_happiness >= 0 && happinessTimer >= 0)
        {
            happinessTimer -= Time.deltaTime;
            if (happinessTimer <= 0)
            {
                ModifyHappiness(-1);
                happinessTimer = maxHappinessTimer;
            }
        }
        if (_energy >= 0 && energyTimer >= 0)
        {
            energyTimer -= Time.deltaTime;
            if (energyTimer <= 0)
            {
                ModifyEnergy(-1);
                energyTimer = maxEnergyTimer;
            }
        }
    }

    private void ModifyHealth(float amt)
    {
        if (_health >= 0)
        {
            _health += amt;
            Debug.Log($"Health: {_health}");
        }
        
    }
    private void ModifyHappiness(float amt)
    {
        if (_happiness >= 0)
        {
           _happiness += amt;
            Debug.LogWarning($"Happiness: {_happiness}");
        }

    }
    private void ModifyEnergy(float amt)
    {
        if (_energy >= 0)
        {
            _energy +=amt;
            //Debug.LogError($"Energy: {_energy}");
        }

    }

    public void EatFood()
    {
        if (foodStats != null && canPlay && closestFood!=null)
        {
            //canEat = false;
            //MyFood.isFoodStatsDisabled = true;
            uIManager.CloseFoodStatsPanel();

           
            CalculateFoodStatsModifier();
            ApplyFoodVariationsToPlayer();
            closestFood.SetActive(false);

        }
    }

   
    //esegue la proporzione per capire quanto un singolo nutriente di un aliento influisce su di una player stats in base ai valori scritti nel foglio
    private float CalculateValueAmount(float modifier,float foodWeight, float refWeight)
    {
        // 3g:+3=food data weight: x
        float value = modifier * foodWeight / refWeight;
        return value;
    }
 

    private float CalculateHealthVariation()
    {
        float carbsHealthAmt = CalculateValueAmount(carbsRefHealthModifier, foodStats.CarboAmount, carbsRefWeight);
        
        float fatsHealthAmt = CalculateValueAmount(fatsRefHealthModifier, foodStats.FatAmount, fatsRefWeight);
        float finalHealthVariation = carbsHealthAmt + fatsHealthAmt;
        //Debug.Log($"Final Health VAriation {finalHealthVariation}");
        return finalHealthVariation;
    }
    private float CalculateHappinessVariation()
    {
        float fatsHappinessAmt = CalculateValueAmount(fatsRefHappinessModifier, foodStats.FatAmount, fatsRefWeight);
        float carbsHappinessAmt = CalculateValueAmount(carbsRefHappinessModifier, foodStats.CarboAmount, carbsRefWeight);
        float finalHappinessVariation = fatsHappinessAmt + carbsHappinessAmt;
        return finalHappinessVariation;
    }
    private float CalculateEnergyVariation()
    {
        float proteinEnergyAmt = CalculateValueAmount(proteinsRefEnergyModifier, foodStats.ProteinAmount, proteinsRefWeight);
        return proteinEnergyAmt;

    }
    private Vector3 CalculateFoodStatsModifier()
    {
        Vector3 foodModifierAmount = new Vector3(CalculateHealthVariation(), CalculateHappinessVariation(), CalculateEnergyVariation());
        Debug.Log($"health_var: {foodModifierAmount.x},  happiness_var: {foodModifierAmount.y} \n energy_var {foodModifierAmount.z}");

        return foodModifierAmount;

    }
    private void ApplyFoodVariationsToPlayer()
    {
        _health += CalculateFoodStatsModifier().x;
        _happiness += CalculateFoodStatsModifier().y;
        _energy += CalculateFoodStatsModifier().z;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }




}
