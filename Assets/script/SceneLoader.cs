using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject greenTank;
    public GameObject yellowTank;

    public DisplayManagerInGame displayManagers;

    public void map1() {
        SceneManager.LoadScene("map1");
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

    public void ReloadLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
