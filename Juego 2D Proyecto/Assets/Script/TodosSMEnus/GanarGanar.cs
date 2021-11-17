using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GanarGanar : MonoBehaviour
{
    float tiempo;
    Load load;
    
    void Awake(){
      load = GameObject.Find("LevelMan").GetComponent (typeof(Load)) as Load;
    }

    void Start()
    {
        tiempo = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= tiempo + 5.0f){
            load.SceneLoad(0);
            Destroy(gameObject);
        }
    }
}
