using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoader : MonoBehaviour
{
    public GameObject greenTank;
    public GameObject yellowTank;

    public displayManagerInGame displayManagers;

    public void map1() {
        SceneManager.LoadScene("map1");
    }

    public void spawnTanksMap1() {
        //Quaternion.identity means no rotation.
        displayManagers.Player1 = Instantiate(greenTank, new Vector3(-3.5f, -2f, 0.5f),Quaternion.identity).GetComponent<baseMovement>();
        displayManagers.Player2 = Instantiate(yellowTank, new Vector3(3.5f, 1.5f, 0.5f),Quaternion.Euler(0, 0, 180)).GetComponent<baseMovement>();
    }

    public void spawnTanksMap2and3and4() {
        //Quaternion.identity means no rotation.
        displayManagers.Player1 = Instantiate(greenTank, new Vector3(-6f, 0f, 0.5f),Quaternion.Euler(0, 0, 270)).GetComponent<baseMovement>();
        displayManagers.Player2 = Instantiate(yellowTank, new Vector3(6f, 0f, 0.5f),Quaternion.Euler(0, 0, 90)).GetComponent<baseMovement>();
    }

    


    public void map2() {
        SceneManager.LoadScene("map2");
    }

    public void map3() {
        SceneManager.LoadScene("map3");
    }
        
    public void map4() {
        SceneManager.LoadScene("map4");
    }

    public void mainMenu() {
        SceneManager.LoadScene("main menu");
    }
}
