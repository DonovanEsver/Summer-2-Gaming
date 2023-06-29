using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1); // Load the 1st level of the game
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void OpenOptionsMenu()
    {

    }
}
