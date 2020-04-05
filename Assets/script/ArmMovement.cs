using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmMovement : MonoBehaviour
{
    public float rotationSpeed; 
    private float rotation;
    public int player;
    public GameObject tankBase;
    public Vector3 localPositionArm;
    public Rigidbody2D rb2d;

    void Start()
    {
         rb2d = GetComponent<Rigidbody2D> ();
    }

    void Update()
    {
        float  RL1 = Input.GetAxis("RL1" + player.ToString());
            if (rotation >= 360 ) {
                 rotation = 0;
             }
            rotation = rotation + RL1 * rotationSpeed * Time.deltaTime;
            transform.localRotation = Quaternion.Euler(0, 0, -rotation);
    }
}
