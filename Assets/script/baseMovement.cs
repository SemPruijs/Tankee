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

    void Start()
    {
         rb2d = GetComponent<Rigidbody2D> ();
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
}
