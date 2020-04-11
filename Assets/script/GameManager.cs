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
    

    public enum State {playing, pause, counting, hasWon, menu};
    public State state = State.pause;
    
    public void playing() {
        state = State.playing;
    }
    
    public void menu()
    {
        state = State.menu;
    }

    public void pause()
    {
        state = State.pause;
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
