using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject David;   
    public static bool veces=false; 

    void Start() {
        veces=false;
    }
    void Update()
    {
        
        if(PauseMenu.GameIsPaused || GameOverMenu.GameIsOver){
            Pause();
            veces=false;
        }
        else if(((!PauseMenu.GameIsPaused) && (!veces)) || ((!GameOverMenu.GameIsOver) && (!veces))){
            Resume();
            veces=true;
        }

        if (David == null)
        {
            return;
        }

        Vector3 position = transform.position;
        position.x= David.transform.position.x;
        if(David.transform.position.y>=-0.03){
            position.y= David.transform.position.y;
        }
        transform.position=position;
    }

    public void Pause(){

        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        foreach (AudioSource a in audios)
        {
            a.Pause();
        }

    }
    public void Resume(){
        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        foreach (AudioSource a in audios)
        {
            a.Play();
        }
    }
}
