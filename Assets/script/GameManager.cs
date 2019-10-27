using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject greenPlayer;
    public GameObject yellowPlayer;
    public GameObject bluePlayer;
    public GameObject pinkPlayer;

    public enum players {green, yellow, blue, pink};
}
