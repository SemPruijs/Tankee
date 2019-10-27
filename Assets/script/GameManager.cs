using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance {
        get {
            if (_instance == null) {
               _instance = new GameManager(); 
            }
            return _instance;
        }
    }


    public GameObject greenPlayer;
    public GameObject yellowPlayer;
    public GameObject bluePlayer;
    public GameObject pinkPlayer;

    public enum players {green, yellow, blue, pink};
    public enum State {playing, pause, counting, hasWon};

    public void destroyTankees() {
        Destroy(greenPlayer);
        Destroy(yellowPlayer);
    }   
}
