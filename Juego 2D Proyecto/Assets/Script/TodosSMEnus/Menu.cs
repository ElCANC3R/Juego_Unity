using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void GameScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PauseMenu.GameIsPaused=false;
        GameOverMenu.GameIsOver=false;
    }

    public void Quit(){
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
