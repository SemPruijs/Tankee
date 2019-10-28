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

    public displayManagerInGame displayManagers;

    //the players
    public GameObject greenTank;
    public GameObject yellowTank;
    public GameObject blueTank;
    public GameObject pinkTank;
    public enum players {green, yellow, blue, pink};



    public enum State {playing, pause, counting, hasWon};
    public State state = State.pause;

    public Scene currentScene;

    void Start() {
        currentScene = SceneManager.GetActiveScene();
        spawnTankees();
    }
    public void destroyTankees() {
        Destroy(greenTank);
        Destroy(yellowTank);
    }   

    public void aTest() {
        print("a test");
    }

    public void spawnTankees() {
        string sceneName = currentScene.name;
        print(sceneName);
        switch (sceneName) {
            case "map2":
            case "map3":
            case "map4":
                displayManagers.Player1 = Instantiate(greenTank, new Vector3(-6f, 0f, 0.5f),Quaternion.Euler(0, 0, 270)).GetComponent<baseMovement>();
                displayManagers.Player2 = Instantiate(yellowTank, new Vector3(6f, 0f, 0.5f),Quaternion.Euler(0, 0, 90)).GetComponent<baseMovement>();
            break;
            case "map1":
                displayManagers.Player1 = Instantiate(greenTank, new Vector3(-3.5f, -2f, 0.5f),Quaternion.identity).GetComponent<baseMovement>();
                displayManagers.Player2 = Instantiate(yellowTank, new Vector3(3.5f, 1.5f, 0.5f),Quaternion.Euler(0, 0, 180)).GetComponent<baseMovement>();
            break;
        }
    }
    public void playing() {
        state = State.playing;
    }
}
