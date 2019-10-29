using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armStuff : MonoBehaviour
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
        float moveHorizontal = Input.GetAxisRaw ("RJX" + player.ToString());
        // float moveVertical = Input.GetAxisRaw ("RJY" + player.ToString());
        if (GameManager.Instance.state == GameManager.State.playing) {
            if (rotation >= 360 ) {
                 rotation = 0;
             }
            rotation = rotation + moveHorizontal * rotationSpeed * Time.deltaTime;
            transform.localRotation = Quaternion.Euler(0, 0, -rotation);
        }
        // transform.localPosition = localPositionArm;
        // rb2d.AddTorque(moveHorizontal * Time.fixedDeltaTime);
        // print(moveVertical);
    }
}
