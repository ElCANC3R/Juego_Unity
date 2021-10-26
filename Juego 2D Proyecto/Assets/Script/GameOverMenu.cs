using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public static bool GameIsOver=false;
    public GameObject GameOverMenuUI;
    private string level=""; 
    void Start()
    {
        level= Application.loadedLevelName;
    }

    // Update is called once per frame
    void Update()
    {
        if(DeivenMove.muerto){
            Pause();
        }
    }

    public void Pause(){
        GameOverMenuUI.SetActive(true);
        Time.timeScale=0f;
        GameIsOver=true;

    }
    public void LoadMenu(){
        DeivenMove.muerto=false;
        GameOverMenuUI.SetActive(false);
        Time.timeScale=1f;
        SceneManager.LoadScene("Menu");
    }

    public void TryAgain(){
        DeivenMove.muerto=false;
        GameOverMenuUI.SetActive(false);
        Time.timeScale=1f;
        SceneManager.LoadScene(level);
        GameOverMenu.GameIsOver=false;
    }
}
