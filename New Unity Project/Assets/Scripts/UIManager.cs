using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour

{
    GameManager gManager;
    [SerializeField]Slider healthSlider;
    [SerializeField] Slider happinessSlider;
    [SerializeField] Slider energySlider;

    private void Start()
    {
        gManager = GetComponent<GameManager>();

    }
    private void Update()
    {
        SyncStats();
    }
    public void SetHealth(float health)
    {
        healthSlider.value = health;
    }
    public void SetHappiness(float happiness)
    {
        happinessSlider.value = happiness;
    }
    public void SetEnergy(float energy)
    {
        energySlider.value = energy;
    }
    private void SyncStats()
    {
        SetHealth(gManager.Health);
        SetHappiness(gManager.Happiness);
        SetEnergy(gManager.Energy);
    }
}
