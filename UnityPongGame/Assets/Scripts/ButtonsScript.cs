using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ButtonsScript : MonoBehaviour
{
    [SerializeField] private Canvas mainMenu;
    [SerializeField] private Canvas settingsMenu;
    [SerializeField] private Canvas creditsMenu;
    public void PlayGame()
    {
        SceneManager.LoadScene("Level_1");
    }
    public void OpenGameSettings()
    {
        mainMenu.enabled = false;
        settingsMenu.enabled = true;
    }
    public void OpenGameCredits()
    {
        mainMenu.enabled = false;
        creditsMenu.enabled = true;
    }
    public void CloseGameSettings()
    {
        mainMenu.enabled = true;
        settingsMenu.enabled = false;
    }
    public void CloseGameCredits()
    {
        mainMenu.enabled = true;
        creditsMenu.enabled = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    } 
}
