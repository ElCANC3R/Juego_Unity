using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public  class Levels : MonoBehaviour
{
    static public int nivelesDesbloqueados;
    public int nivelActual;
    public  Button[] botonesMenu;

    void start(){
        if(SceneManager.GetActiveScene ().name == "Menu"){
            //actualizarBotones();
        }
    }

    public void cargaNivel(int scene)
    {
        SceneManager.LoadScene(scene);
        //PauseMenu.GameIsPaused=false;
        //GameOverMenu.GameIsOver=false;
    }

    public void desbloquearNivel(int i){
        if(nivelesDesbloqueados < nivelActual){
            nivelesDesbloqueados = nivelActual;
            nivelActual++;
        }
        volverMenu();
    }

    public void activarBtn(int btn){
        botonesMenu[btn].interactable = true;
    }

    public void volverMenu(){
        cargaNivel(0);
        //desbloquearNivel();
    }
}
