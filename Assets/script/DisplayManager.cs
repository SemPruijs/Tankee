using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject inGame;
    public GameObject pause;
    void Update()
    {
        menu.SetActive(GameManager.Instance.state == GameManager.State.menu);
        inGame.SetActive(GameManager.Instance.state == GameManager.State.playing);
        pause.SetActive(GameManager.Instance.state == GameManager.State.pause);
    }
}
