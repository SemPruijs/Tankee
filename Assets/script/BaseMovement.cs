using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMovement : MonoBehaviour
{
    //----------------- Player ------------------

    public int player;
    private Rigidbody2D rb2d;
    public int heath;

    private float _normalMoveSpeed;
    private float _normalRotationSpeed;

    
    //----------------- movement ------------------
    private float _moveSpeed = 900;  
    private float _currentRotation;
    private float _rotationSpeed = 25;
    private float _angle;

    private float _moveHorizontal;
    private float _moveVertical;

    //----------------- audio ------------------

    //clips
    public AudioClip deadSound;
    public AudioClip impactSound;
    public AudioClip speedPowerUpSound;
    
    //source
    public AudioSource audioSource;


    
    //----------------- Power up ------------------    
    private float _timeSpeedPowerUp;

    //----------------- Start ------------------
    void Start()
    {
         audioSource = GameObject.FindWithTag ("audioSource").GetComponent<AudioSource>();
         rb2d = GetComponent<Rigidbody2D> ();
         heath =+ 30;

         //store normal speed
         _normalMoveSpeed = _moveSpeed;
         _normalRotationSpeed = _rotationSpeed;
    }

    //----------------- Update ------------------
    private void Update()
    {
        //input manager
        _moveHorizontal = Input.GetAxis ("LJX" + player.ToString());
        _moveVertical = Input.GetAxis ("LJY" + player.ToString());
        
        //powerup count down
        _timeSpeedPowerUp -= Time.deltaTime;
        if (_timeSpeedPowerUp <= 0)
        {
            _moveSpeed = _normalMoveSpeed;
            _rotationSpeed = _normalRotationSpeed;
        }
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
        if (collision.gameObject.CompareTag("shieldPowerUp")) {
            Destroy(collision.gameObject);
        }
    }

    
    //----------------- In game ------------------
    
    void damage() {
        audioSource.PlayOneShot(impactSound, 0.1F);
        heath -= 1;
    }
    
    void speedPowerUp() {
        _timeSpeedPowerUp = 15f;
        _moveSpeed = 1500;
        _rotationSpeed = 80;
        audioSource.PlayOneShot(speedPowerUpSound, 1.0F);
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
