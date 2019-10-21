using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayManagerInGame : MonoBehaviour
{
    public Text scorePlayer1;
    public Text scorePlayer2;

    public GameObject Player1;
    public GameObject Player2;

    public baseMovement PlayerScript1;
    public baseMovement PlayerScript2;

    void Start() {
        PlayerScript1 = Player1.GetComponent<baseMovement>();
        PlayerScript2 = Player2.GetComponent<baseMovement>();

        print("test");
    }

    void Update() {
        scorePlayer1.text = PlayerScript1.heath.ToString();
        scorePlayer2.text = PlayerScript2.heath.ToString();
    }
}
