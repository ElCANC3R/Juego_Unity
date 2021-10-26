using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Volume : MonoBehaviour
{
    [SerializeField] Slider volume;
    void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolume")){
            PlayerPrefs.SetFloat("musicVolume",1);
            load();
        }
        else{
            load();
        }
    }

    public void ChangeVolume(){
        AudioListener.volume= volume.value;
        save();
    }

    public void load(){
        volume.value=PlayerPrefs.GetFloat("musicVolume");
    }

    public void save(){
        PlayerPrefs.SetFloat("musicVolume",volume.value);
    }
}
