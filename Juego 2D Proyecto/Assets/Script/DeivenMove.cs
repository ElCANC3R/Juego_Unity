using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeivenMove : MonoBehaviour
{
    public float Speed;
    public float JumpForce=450;
    private Rigidbody2D Rigidbody2D;
    private float Horizontal;
    private Animator Animator;
    private bool Grounded;
    private bool Golpe;

    void Start()
    {
        Rigidbody2D=GetComponent<Rigidbody2D>();
        Animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal= Input.GetAxisRaw("Horizontal");
       
        Animator.SetBool("Walk",Horizontal !=0.0f);
        Animator.SetBool("Punch",Input.GetKeyDown(KeyCode.K));       
        
        if(Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f,1.0f,1.0f);
        else if(Horizontal > 0.0f) transform.localScale = new Vector3(1.0f,1.0f,1.0f);

        Debug.DrawRay(transform.position, Vector3.down * 1f, Color.red);
        if(Physics2D.Raycast(transform.position, Vector3.down, 1f)){
            Grounded = true;
        }
        else Grounded = false;
      
        if(Input.GetKeyDown(KeyCode.W)&& Grounded){
            Jump();
        }
    }

    private void Jump(){
        Rigidbody2D.AddForce(Vector2.up*450);
    }
    private void FixedUpdate(){
        Rigidbody2D.velocity=new Vector2(Horizontal*Speed,Rigidbody2D.velocity.y);
       
    }
}
