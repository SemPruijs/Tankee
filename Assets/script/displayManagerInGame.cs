using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayManagerInGame : MonoBehaviour
{
    public Text scorePlayer1;
    public Text scorePlayer2;
    public baseMovement Player1;
    public baseMovement Player2;

    void Update() {
        scorePlayer1.text = Player1.heath.ToString();
        scorePlayer2.text = Player2.heath.ToString();
    }
}
