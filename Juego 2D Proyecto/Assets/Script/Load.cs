using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Load : MonoBehaviour
{
    [SerializeField]private Slider load;
    [SerializeField]private GameObject loadpanel;
    [SerializeField]private TextMeshProUGUI textprogress;

    public void SceneLoad(int Scene){
        loadpanel.SetActive(true);
        StartCoroutine(LoadAsync(Scene));
        PauseMenu.GameIsPaused=false;
        GameOverMenu.GameIsOver=false;
    }
    
    public void SceneLoad(){
        loadpanel.SetActive(true);
        int Scene = SceneManager.GetActiveScene().buildIndex + 1; 
        StartCoroutine(LoadAsync(Scene));
        PauseMenu.GameIsPaused=false;
        GameOverMenu.GameIsOver=false;
    }

    IEnumerator LoadAsync(int Scene){
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(Scene);
        while(!asyncOperation.isDone){
            load.value=asyncOperation.progress / 0.9f;
            textprogress.text= "" + ((asyncOperation.progress / 0.9f)*100) + "%";
            yield return null;
        }
    }
}
