using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private bool _gameHasEnded = false;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        _gameHasEnded = false;
    }

    public void EndGame() 
    {
        if (_gameHasEnded == false) 
        {
            _gameHasEnded = true;
            Invoke("ReloadCurrentScene", 2f);
        }
    }


    private void ReloadCurrentScene()
    {
        // Reset the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reloads current scene
    }

    
}
