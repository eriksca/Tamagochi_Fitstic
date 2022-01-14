using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float _health;
    private float _happiness;
    private float _energy;
   
    public float Health { get { return _health; } }
    public float Happiness { get { return _happiness; } }
    public float Energy { get { return _energy; } }
   
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
        _health = 100;
        _happiness = 100;
        _energy = 100;
        canPlay = true;
        //InvokeRepeating(nameof(ModifyHealth), 2f, 3f);
    }

    // Update is called once per frame
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
            Debug.LogError($"Energy: {_energy}");
        }

    }

    


}
