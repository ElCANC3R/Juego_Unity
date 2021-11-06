using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    public static int nivelesDesbloqueados;
    public int nivelActual;
    public  Button[] botonesMenu;

    void Start(){
        if(SceneManager.GetActiveScene().name == "Menu"){
            actualizarBotones();
        }
    }

    public void cargaNivel(string scene)
    {
        SceneManager.LoadScene(scene);
        
        //PauseMenu.GameIsPaused=false;
        //GameOverMenu.GameIsOver=false;
    }

    public void desbloquearNivel(){
        if(nivelesDesbloqueados < nivelActual){
            nivelesDesbloqueados = nivelActual;
            nivelActual++;
        }
        cargaNivel("Menu");
    }

    public void actualizarBotones(){
        Debug.Log("niveles desbloqueados: " + nivelesDesbloqueados + " size: " + botonesMenu.Length);
        Debug.Log("Escena actual: "+ SceneManager.GetActiveScene().name);
        for(int i = 0; i < nivelesDesbloqueados+1; i++){
            botonesMenu[i].interactable = true;
            Debug.Log("Hola "+i);
        }
    }

    /*public void volverMenu(){
        cargaNivel("Menu");
        //desbloquearNivel();
    }*/
}