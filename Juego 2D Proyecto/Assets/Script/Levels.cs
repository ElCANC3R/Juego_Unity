using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    public void cargaNivel(int scene)
    {
        SceneManager.LoadScene(scene);
        PauseMenu.GameIsPaused=false;
        GameOverMenu.GameIsOver=false;
    }
}