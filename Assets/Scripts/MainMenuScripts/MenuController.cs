using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public Button Play;
    public Button Help;
    public Button Credits;
    public Button HelpBack;
    public Button CreditsBack;
    public Button QuitButton;

    public GameObject MainMenuPannel;
    public GameObject HelpPannel;
    public GameObject CreditsPannel;

    void Start()
    {
        // Initialises each button and what they do
        Play.onClick.AddListener(PlayGame);
        Help.onClick.AddListener(HelpMenu);
        Credits.onClick.AddListener(OpenCredits);
        HelpBack.onClick.AddListener(Menu);
        CreditsBack.onClick.AddListener(Menu);
        QuitButton.onClick.AddListener(QuitGame);
    }

    void PlayGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    void HelpMenu()
    {
        MainMenuPannel.SetActive(false);
        HelpPannel.SetActive(true);
    }

    void OpenCredits()
    {
        MainMenuPannel.SetActive(false);
        CreditsPannel.SetActive(true);
    }

    void Menu()
    {
        MainMenuPannel.SetActive(true);
        HelpPannel.SetActive(false);
        CreditsPannel.SetActive(false);
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
