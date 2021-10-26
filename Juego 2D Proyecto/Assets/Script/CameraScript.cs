using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject David;   
    public static bool veces=false; 
    private string level=""; 
    private float volume;
    void Start() {
        veces=false;
        level= Application.loadedLevelName;
        if(PlayerPrefs.HasKey("musicVolume")){
            volume=PlayerPrefs.GetFloat("musicVolume");
            AudioListener.volume= volume;
        }
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
        if(level == "First Level"){
            if(David.transform.position.y>=0.19){
                position.y= David.transform.position.y;
            }
        }
        else if(level == "Second Level"){
            if(David.transform.position.y>=-6.47){
                position.y= David.transform.position.y;
            }
        }
        else if(level == "Third Level"){
            if(David.transform.position.y>=-6.47){
                position.y= David.transform.position.y;
            }
        }
        else if(level == "Fourth Level"){
            if(David.transform.position.y>=-6.47){
                position.y= David.transform.position.y;
            }
        }
        else if(level == "Fifth Level"){
            if(David.transform.position.y>=-6.47){
                position.y= David.transform.position.y;
            }
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
