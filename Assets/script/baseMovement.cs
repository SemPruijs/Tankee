using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseMovement : MonoBehaviour
{
    public float moveSpeed;  
    private float rotation;   
    public float rotationSpeed;      
    public int player;
    private Rigidbody2D rb2d;
    public int heath;
    public float angle;

    public AudioClip deadSound;
    public AudioClip impactSound;
    public AudioSource audioSource;
    void Start()
    {
         rb2d = GetComponent<Rigidbody2D> ();
         heath =+ 30;
         audioSource = GameObject.FindWithTag ("audioSource").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            float moveHorizontal = Input.GetAxis ("LJX" + player.ToString()); 
            float moveVertical = Input.GetAxis ("LJY" + player.ToString());

        // if (moveHorizontal != 0.0f || moveVertical != 0.0f) {
        //     angle = Mathf.Atan2(moveVertical, -moveHorizontal) * Mathf.Rad2Deg;
        //     //rb2d.velocity = transform.up * Time.deltaTime * moveSpeed;
      
        // rotation = rotation + moveHorizontal * rotationSpeed * Time.deltaTime;

        // transform.rotation = Quaternion.Euler(0, 0, -rotation);
        if (GameManager.Instance.state == GameManager.State.playing) {
            rb2d.AddForce(transform.up * Time.fixedDeltaTime * moveSpeed * -moveVertical);
            rb2d.AddTorque(-rotationSpeed * moveHorizontal * Time.fixedDeltaTime);
        }
            
        //     if  (transform.rotation != Quaternion.Euler(0, 0, angle + 90.0f)) {
        //         transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, angle + 90.0f), rotationSpeed * Time.deltaTime);
        //     }
        // }
    }

    void damage() {
        audioSource.PlayOneShot(impactSound, 0.1F);
        heath = heath - 1;
        print(heath.ToString());
    }

    void whoHasWon() {
        if (player == 1) {
            //yellow
            GameManager.Instance.hasWonString = "Yellow player wins!";
        } else {
            //green
            GameManager.Instance.hasWonString = "Green player wins!";
        }
    }

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
    }
}
