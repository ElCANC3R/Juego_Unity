using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float distance;
    private bool movingRight = true;
    public Transform groundDeteccion;
    // Update is called once per frame
    void Update()
    {
     transform.Translate(Vector2.left * speed *Time.deltaTime);
     RaycastHit2D groundInfo = Physics2D.Raycast(groundDeteccion.position,Vector2.down,distance);
     if(groundInfo.collider == false){
         if(movingRight == true){
            transform.eulerAngles = new Vector3(0,-180,0);
            movingRight = false;
         }else{
            transform.eulerAngles = new Vector3(0,0,0);
            movingRight = true; 
         }
     }   
    }
    private void OnCollisionEnter2D(Collision2D other){
        if(other.collider.CompareTag("Player")){
            
        }else{
            if(movingRight == true){
                transform.eulerAngles = new Vector3(0,-180,0);
                movingRight = false;
            }else{
                transform.eulerAngles = new Vector3(0,0,0);
                movingRight = true; 
            }

      }
    }
}
