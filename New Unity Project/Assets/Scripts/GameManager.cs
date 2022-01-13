using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float health;
    private float happiness;
    private float energy;
   
    private float healthDecrement = 0.01f; // -1% ogni 10 sec
    private float happinessDecrement = 0.01f; // -1% ogni 20 sec
    private float energyDecrement = 0.01f; // -1% ogni 30 secondi

    public float Health { get { return health; } }
    public float Happiness { get { return happiness; } }
    public float Energy { get { return energy; } }
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        happiness = 100;
        energy = 100;
        InvokeRepeating(nameof(DecrementHealth), 2f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 || happiness <= 0 || energy <= 0)
        {
            // distruggi la sfera
        }
    }

    private void DecrementHealth()
    {
        if (health >= 0)
        {
            health -= 1;
            Debug.Log(health);
        }
        
    }
}
