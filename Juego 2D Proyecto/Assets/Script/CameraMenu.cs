using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMenu : MonoBehaviour
{
    private float volume;
    void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolume")){
            PlayerPrefs.SetFloat("musicVolume",1);
        }
        else{
            volume=PlayerPrefs.GetFloat("musicVolume");
            AudioListener.volume= volume;
        }
    }

    void Update()
    {
        
    }
}
