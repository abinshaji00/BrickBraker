using JetBrains.Annotations;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Switch : MonoBehaviour
{
    
    public void NewGame()
    {
        SceneManager.LoadScene("Global");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void nextLevel()
    {
        FindObjectOfType<GameManager>().next();
    }
    public void RestartLevel()
    {
        FindObjectOfType<GameManager>().playAgain();
    }
}
