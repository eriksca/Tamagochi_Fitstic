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
    [SerializeField] TMP_Text health_Text;
    [SerializeField] TMP_Text happiness_Text;
    [SerializeField] TMP_Text energy_Text;
    [SerializeField] TMP_Text time_Text;

    public TMP_Text foodStatsText;
    public Image foodImg;
    [SerializeField] GameObject foodStatsPanel;
    [SerializeField] GameObject gameOverPanel;
    private bool gameOver;
    

    private void Start()
    {
        gManager = GetComponent<GameManager>();
        gameOver = false;
        CloseFoodStatsPanel();
        ManagePanel(gameOverPanel, false);

    }
    private void Update()
    {
        SyncStats();
        if (!GameManager.canPlay)
        {
            ManagePanel(gameOverPanel, true);
            gameOver = true;
        }
        
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
        SyncTexts();
    }
    private void SyncTexts()
    {
        health_Text.text = gManager.Health.ToString();
        happiness_Text.text = gManager.Happiness.ToString();
        energy_Text.text = gManager.Energy.ToString();
        time_Text.text = gManager.PlayTime.ToString();
    }

    public void OpenFoodStatsPanel()
    {
        foodStatsPanel.SetActive(true);
    }
    public void CloseFoodStatsPanel()
    {
        if (foodStatsPanel!=null && !foodStatsPanel.activeInHierarchy)
        {
            return;
        }

        foodStatsPanel.SetActive(false);
    }
    public void ManagePanel(GameObject panel,bool isActive)
    {
        panel.SetActive(isActive);
    }
    

    
}
