using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoLadron : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    private Rigidbody2D Rigidbody2D;
    private float Horizontal;
    private float Vertical;
    // Start is called before the first frame update
    private Animator Animator;

    void Start()
    {
        Rigidbody2D=GetComponent<Rigidbody2D>();
        Animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal= Input.GetAxisRaw("Horizontal");
        //Vertical= Input.GetAxisRaw("Vertical");

        Animator.SetBool("Up",Vertical >0.0f);
        Animator.SetBool("Down",Vertical <0.0f);
        
        if(Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f,1.0f,1.0f);
        else if(Horizontal > 0.0f) transform.localScale = new Vector3(1.0f,1.0f,1.0f);

        /*if(Input.GetKeyDown(KeyCode.W)){
            Jump();
        }*/
    }

    /*private void Jump(){
        Rigidbody2D.AddForce(Vector2.up*JumpForce);
    }*/
    private void FixedUpdate(){
        Rigidbody2D.velocity=new Vector2(Horizontal*Speed,Rigidbody2D.velocity.y);
        //Rigidbody2D.velocity=new Vector2(Rigidbody2D.velocity.x,Vertical*Speed);
    }
}
