using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyStats : MonoBehaviour
{

    public int MaxEnemyHealth;
    public float EnemyHealth;
    public float PercentageHealth;
    public int MaxEnergyLevel;
    public float EnergyLevel;
    public float PercentageEnergy;


    public Image EnemyHealthBar;
    public Image EnemyEnergyBar;

    public GameObject VictoryPannel;

    // When the scene is loaded and by extension this script, the victory screen is disabled
    void Awake()
    {
        VictoryPannel.SetActive(false);
    }

    void Start()
    {
        MaxEnemyHealth = 100;
        EnemyHealth = MaxEnemyHealth;
        MaxEnergyLevel = 100;
        EnergyLevel = 0;
    }

    void Update()
    {
        // Updates the enemy's visual health bar
        PercentageHealth = EnemyHealth / MaxEnemyHealth;
        EnemyHealthBar.fillAmount = PercentageHealth;

        // If the enemy has no health left a victory screen is displayed and the game returns to the main menu
        if (EnemyHealth <= 0)
        {
            EnemyHealth = 0;
            VictoryPannel.SetActive(true);
            StartCoroutine(BackToMenu());
        }
        // Increases the enemy's Energy level by 0.06 each frame, this should ammount to 3.6 energy per second
        EnergyLevel += 0.06f;
        // If the energy level excedes the maximum then the energy is set to the maximum.
        if (EnergyLevel > MaxEnergyLevel)
        {
            EnergyLevel = MaxEnergyLevel;
        }
        // Updates the enemy's visual energy bar
        PercentageEnergy = EnergyLevel / MaxEnergyLevel;
        EnemyEnergyBar.fillAmount = PercentageEnergy;
    }
    IEnumerator BackToMenu()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("MainMenu");
    }
}