using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destroy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other){
      if(other.collider.CompareTag("Player")){
        DeivenMove.muerto=true;
        Destroy(other.gameObject);
      }
    }
}
