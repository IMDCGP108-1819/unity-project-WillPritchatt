using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour {

    public int MaxPlayerHealth;
    public float PlayerHealth;
    public float PercentageHealth;
    public int MaxEnergyLevel;
    public float EnergyLevel;
    public float PercentageEnergy;

    public Image PlayerHealthBar;
    public Image EnergyLevelBar;

    public GameObject GameOverPannel;

    // When this scene is loaded and by extension this script, the Game Over screen is disabled
    void Awake()
    {
        GameOverPannel.SetActive(false);    
    }

    void Start()
    {
        MaxPlayerHealth = 100;
        MaxEnergyLevel = 100;
        EnergyLevel = 0;
        PlayerHealth = MaxPlayerHealth;
    }

    void Update()
    {
        // Updates the player's visual heath bar
        PercentageHealth = PlayerHealth / MaxPlayerHealth;
        PlayerHealthBar.fillAmount = PercentageHealth;
        
        // If the player has no HP left then a game over screen is displayed and the game returns to the main menu
        if (PlayerHealth <= 0)
        {
            PlayerHealth = 0;
            GameOverPannel.SetActive(true);
            StartCoroutine(BackToMenu());
        }
        // Increases the player's energy level by 0.06 every frame, or 3.6 energy per second
        EnergyLevel += 0.06f;
        // If the player's energy level excede the maximum, their energy is set to the maximum
        if (EnergyLevel > MaxEnergyLevel)
        {
            EnergyLevel = MaxEnergyLevel;
        }
        // Updates the enemy's visual energy bar
        PercentageEnergy = EnergyLevel / MaxEnergyLevel;
        EnergyLevelBar.fillAmount = PercentageEnergy;
    }
    IEnumerator BackToMenu()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("MainMenu");
    }
}
