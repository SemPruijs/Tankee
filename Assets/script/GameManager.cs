using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance {
        get {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }
    
    //the players
    public GameObject greenTank;
    public GameObject yellowTank;
    public GameObject blueTank;
    public GameObject pinkTank;
    public enum player {green, yellow, blue, pink};

    public enum State {playing, pause, counting, hasWon, menu};
    public State state = State.pause;
    public string hasWonString;

    public int map;
    
    public void playing() {
        state = State.playing;
    }
    
    public void menu()
    {
        state = State.menu;
    }

    public void counting()
    {
        state = State.counting;
    }

    void Start()
    {
        menu();
    }
}
