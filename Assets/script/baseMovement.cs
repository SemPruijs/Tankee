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
    private float _moveSpeed = 900;  
    private float _currentRotation;
    private float _rotationSpeed = 25;
    private float _angle;

    private float _moveHorizontal;
    private float _moveVertical;

    //----------------- audio ------------------

    public AudioClip deadSound;
    public AudioClip impactSound;
    public AudioSource audioSource;

    
    //----------------- Power up ------------------    
    public float TimeSpeed;

    //----------------- Start ------------------
    void Start()
    {
         audioSource = GameObject.FindWithTag ("audioSource").GetComponent<AudioSource>();
         rb2d = GetComponent<Rigidbody2D> ();
         heath =+ 30;
    }

    //----------------- Update ------------------
    private void Update()
    {
        _moveHorizontal = Input.GetAxis ("LJX" + player.ToString());
        _moveVertical = Input.GetAxis ("LJY" + player.ToString());    
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.state == GameManager.State.playing) {
            rb2d.AddForce(transform.up * Time.fixedDeltaTime * _moveSpeed * -_moveVertical);
            rb2d.AddTorque(-_rotationSpeed * _moveHorizontal * Time.fixedDeltaTime);
        }
            
    }

    //----------------- Collision ------------------
    
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("bullet")) {
            if (heath == 1) {
                determineWhoHasWon();    
                audioSource.PlayOneShot(deadSound, 1.0F);
                GameManager.Instance.state = GameManager.State.hasWon;
                Destroy(gameObject);
            } else {
                damage();
            }
        }
        if (collision.gameObject.CompareTag("speedPowerUp")) {
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
        _moveSpeed = 1500;
        _rotationSpeed = 80;
    }

    //----------------- After game ------------------
    
    void determineWhoHasWon() {
        if (player == 1) {
            //yellow
            GameManager.Instance.hasWonString = "Yellow player wins!";
        } else {
            //green
            GameManager.Instance.hasWonString = "Green player wins!";
        }
    }
}
