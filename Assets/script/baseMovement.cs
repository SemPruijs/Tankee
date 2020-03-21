using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseMovement : MonoBehaviour
{
    //----------------- Player ------------------

    public int player;
    private Rigidbody2D rb2d;
    public int heath;
    
    //----------------- movement ------------------
    public float moveSpeed;  
    private float _currentRotation;
    public float rotationSpeed;
    public float angle;

    private float _moveHorizontal;
    private float _moveVertical;

    //----------------- audio ------------------

    public AudioClip deadSound;
    public AudioClip impactSound;
    public AudioSource audioSource;

    
    //----------------- Power up ------------------    
    //time for powerup
    public float TimeSpeed;
    
    
    
    
    //----------------- Start ------------------
    void Start()
    {
         rb2d = GetComponent<Rigidbody2D> ();
         heath =+ 30;
         audioSource = GameObject.FindWithTag ("audioSource").GetComponent<AudioSource>();
    }

    //----------------- Update ------------------
    private void Update()
    {
        _moveVertical= Input.GetAxis ("LJX" + player.ToString());
        _moveVertical = Input.GetAxis ("LJY" + player.ToString());    
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.state == GameManager.State.playing) {
            rb2d.AddForce(transform.up * Time.fixedDeltaTime * moveSpeed * -_moveVertical);
            rb2d.AddTorque(-rotationSpeed * _moveHorizontal * Time.fixedDeltaTime);
        }
            
    }

    //----------------- Collision ------------------
    
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "bullet") {
            if (heath == 1) {
                whoHasWon();    
                audioSource.PlayOneShot(deadSound, 1.0F);
                GameManager.Instance.state = GameManager.State.hasWon;
                Destroy(gameObject);
            } else {
                damage();
            }
        }
        if (collision.gameObject.tag == "speedPowerUp") {
            Destroy(collision.gameObject);
            speedPowerUp();
        }
    }

    
    //----------------- In game ------------------
    
    void damage() {
        audioSource.PlayOneShot(impactSound, 0.1F);
        heath = heath - 1;
        print(heath.ToString());
    }
    
    void speedPowerUp() {
        TimeSpeed = 30f;
        moveSpeed = 1500;
        rotationSpeed = 80;
    }

    //----------------- After game ------------------
    
    void whoHasWon() {
        if (player == 1) {
            //yellow
            GameManager.Instance.hasWonString = "Yellow player wins!";
        } else {
            //green
            GameManager.Instance.hasWonString = "Green player wins!";
        }
    }

   

}
