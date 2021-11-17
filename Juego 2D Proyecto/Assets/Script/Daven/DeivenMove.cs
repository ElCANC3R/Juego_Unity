using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeivenMove : MonoBehaviour
{
    public GameObject BulletPrefav;
    public float Speed;
    public float JumpForce = 450;
    private Rigidbody2D Rigidbody2D;
    private float Horizontal;
    private Animator Animator;
    private bool Grounded;
    private bool Golpe;
    private float LastShoot;
    public GameObject SpecialBulletPrefav;
    private float LastShootEsp;

    // Variables de Vida y Experiencia
    public Slider VidaSlider;
    public float danoBullet = 0.1f;
    public static bool muerto = false;
    public Slider EneSlider;
    public float gastoEsp = 0.3f;

    // Variables de Buffs
    public float AumVida;

    public float AumEne;

    private bool IsEnerInfi = false;
    private float IniEnerInfi;
    public float TempEnerInfi;

    private bool IsVel = false;
    private float IniVel;
    public float TempVel;
    public int VelVelBuff;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();

        VidaSlider.value = 1f;
        EneSlider.value = 1f;

    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        Animator.SetBool("Walk", Horizontal != 0.0f);
        Animator.SetBool("Punch", Input.GetKeyDown(KeyCode.K));

        if (Input.GetKeyDown(KeyCode.K) && Time.time > LastShoot + 0.3f)
        {
            Shoot();
            LastShoot = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > LastShootEsp + 5.0f && EneSlider.value >= 0.3 || Input.GetKeyDown(KeyCode.Space) && Time.time > LastShootEsp + 5.0f && IsEnerInfi == true)
        {
            ShootEsp();
            LastShootEsp = Time.time;
        }



        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        Debug.DrawRay(transform.position, Vector3.down * 1f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 1f))
        {
            Grounded = true;
        }
        else Grounded = false;

        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }

        if (Time.time >= IniEnerInfi + TempEnerInfi)
        {
            IsEnerInfi = false;
        }

        if (Time.time >= IniVel + TempVel)
        {
            IsVel = false;
        }

    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * 500);
    }

    private void Shoot()
    {
        Vector3 direction;
        bool Kalan69;
        if (transform.localScale.x == 1.0f)
        {
            direction = Vector3.right;
            Kalan69 = false;
        }
        else
        {
            direction = Vector3.left;
            Kalan69 = true;
        }

        /*GameObject bullet = Instantiate(BulletPrefav, transform.position + direction * 0.1f, Quaternion.identity); 
        bullet.GetComponent<Bullet>().SetDirection(direction);*/

        GameObject bullet = Instantiate(BulletPrefav, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<Bullet2>().SetDirection(direction);
        if (Kalan69)
        {
            bullet.GetComponent<Bullet2>().SetKALAN();
        }
    }
    private void FixedUpdate()
    {
        if (IsVel == true)
        {
            Rigidbody2D.velocity = new Vector2(Horizontal * VelVelBuff, Rigidbody2D.velocity.y);
        }
        else
        {
            Rigidbody2D.velocity = new Vector2(Horizontal * 3, Rigidbody2D.velocity.y);
        }



    }

    public void DanoRecibido()
    {
        VidaSlider.value -= danoBullet;

        Animator.SetTrigger("Damage");

        if (VidaSlider.value <= 0)
        {
            muerto = true;
            Destroy(gameObject);
        }
    }

    public void DanoRecibido2()
    {
        VidaSlider.value -= 0.25f;

        Animator.SetTrigger("Damage");

        if (VidaSlider.value <= 0)
        {
            muerto = true;
            Destroy(gameObject);
        }
    }

    private void ShootEsp()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector3.right;
        else direction = Vector3.left;

        GameObject bullet = Instantiate(SpecialBulletPrefav, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletPro>().SetDirection(direction);

        if (IsEnerInfi == false)
        {
            EneSlider.value -= gastoEsp;
        }

    }

    public void AumentoVida()
    {
        VidaSlider.value += AumVida;
    }

    public void AumentoEner()
    {
        EneSlider.value += AumEne;
    }

    public void EnerInfi()
    {

        IsEnerInfi = true;
        IniEnerInfi = Time.time;

    }

    public void SaltBuf()
    {

        IsVel = true;
        IniVel = Time.time;

    }

}
