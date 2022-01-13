using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float health;
    private float happiness;
    private float energy;
   
    public float Health { get { return health; } }
    public float Happiness { get { return happiness; } }
    public float Energy { get { return energy; } }
   
    /// <summary>
    /// timer variables utili per gestire le funzioni di decremento statistiche player durante l'esecuzione
    /// </summary>
    private float healthTimer =10f;
    private float happinessTimer=20f;
    private float energyTimer=30f;

    [SerializeField] float maxHealthTimer;
    [SerializeField] float maxHappinessTimer;
    [SerializeField] float maxEnergyTimer;

    public static bool canPlay;
    
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        happiness = 100;
        energy = 100;
        canPlay = true;
        //InvokeRepeating(nameof(ModifyHealth), 2f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 || happiness <= 0 || energy <= 0)
        {
            canPlay = false;
            return;
        }
        ManagePlayerStats();
    }

    private void ManagePlayerStats()
    {
        if (health >= 0 && healthTimer >= 0)
        {
            //Debug.Log(healthTimer);
            healthTimer -= Time.deltaTime;
            if (healthTimer <= 0)
            {
                ModifyHealth(-1);
                healthTimer = maxHealthTimer;
            }
        }
        if (happiness >= 0 && happinessTimer >= 0)
        {
            happinessTimer -= Time.deltaTime;
            if (happinessTimer <= 0)
            {
                ModifyHappiness(-1);
                happinessTimer = maxHappinessTimer;
            }
        }
        if (energy >= 0 && energyTimer >= 0)
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
        if (health >= 0)
        {
            health += amt;
            Debug.Log($"Health: {health}");
        }
        
    }
    private void ModifyHappiness(float amt)
    {
        if (happiness >= 0)
        {
           happiness += amt;
            Debug.LogWarning($"Happiness: {happiness}");
        }

    }
    private void ModifyEnergy(float amt)
    {
        if (energy >= 0)
        {
            energy +=amt;
            Debug.LogError($"Energy: {energy}");
        }

    }

    


}
