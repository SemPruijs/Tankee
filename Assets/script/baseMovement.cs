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

    void Start()
    {
         rb2d = GetComponent<Rigidbody2D> ();
         heath =+ 30;
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw ("LJX" + player.ToString());
        float moveVertical = Input.GetAxisRaw ("LJY" + player.ToString());

        rotation = rotation + moveHorizontal * rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.Euler(0, 0, -rotation);

        //transform.Translate(transform.up * moveSpeed * Time.deltaTime * moveVertical);

        rb2d.velocity = transform.up * Time.deltaTime * moveSpeed * -moveVertical;
    }

    void damage() {
        heath = heath - 1;
        print(heath.ToString());
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "bullet") {
            Destroy(collision.gameObject);
            if (heath == 0) {
                Destroy(gameObject);
            } else {
                damage();
            }
        }
    }
}
