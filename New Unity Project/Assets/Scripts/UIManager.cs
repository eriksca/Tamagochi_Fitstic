using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour

{
    GameManager gManager;
    [SerializeField]Slider healthSlider;
    [SerializeField] Slider happinessSlider;
    [SerializeField] Slider energySlider;

    public TMP_Text foodStatsText;
    public Image foodImg;
    [SerializeField] GameObject foodStatsPanel;
    

    private void Start()
    {
        gManager = GetComponent<GameManager>();
        CloseFoodStatsPanel();

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

    public void OpenFoodStatsPanel()
    {
        foodStatsPanel.SetActive(true);
    }
    public void CloseFoodStatsPanel()
    {
        if (!foodStatsPanel.activeInHierarchy)
        {
            return;
        }

        foodStatsPanel.SetActive(false);
    }

    
}
