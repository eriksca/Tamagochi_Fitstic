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
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        happiness = 100;
        energy = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
