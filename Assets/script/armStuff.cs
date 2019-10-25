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

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw ("RJX" + player.ToString());
        float moveVertical = Input.GetAxisRaw ("RJY" + player.ToString());
        if (rotation >= 360 ) {
            rotation = 0;
        }
        rotation = rotation + moveHorizontal * rotationSpeed * Time.deltaTime;

        transform.localRotation = Quaternion.Euler(0, 0, -rotation);
        transform.localPosition = localPositionArm;

        print(moveVertical);
    }
}
