using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Next : MonoBehaviour
{
    Levels levels;
    Load load;
    void Awake(){
      levels = GameObject.Find("LevelMan").GetComponent (typeof(Levels)) as Levels;
      load = GameObject.Find("LevelMan").GetComponent (typeof(Load)) as Load;
    }

    private void OnCollisionEnter2D(Collision2D other){
      if(other.collider.CompareTag("Player")){
        levels.desbloquearNivel();
        load.SceneLoad();
 
      }
    }
}