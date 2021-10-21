using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other){
      if(other.collider.CompareTag("Player")){
        SceneManager.LoadScene("Second Level",LoadSceneMode.Single);
      }
    }
}
