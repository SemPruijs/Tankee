using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class GenerateMap : MonoBehaviour
{
    //-------------------- Scripts --------------------
    public DisplayManagerInGame displayManager;
    
    //-------------------- Prefabs --------------------
    public GameObject wallPrefab;
    public GameObject powerUpSpawner;

    public GameObject greenPlayer;
    public GameObject yellowPlayer;
    
    //-------------------- wall positions --------------------
    
    //map 0
    private float[,] wallPositionsMap0 =
    {
        {-3.5f, 3.5f, -2.5f, 2.5f, -2.5f, 2.5f, -3.5f, 3.5f}, // x
        {3f, 3f, 2f, 2f, -2f, -2f, -3f, -3f}, // y
        {0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f}, // z
        {0f, 0f, 90f, 90f, 90f, 90f, 0f, 0f} // rotation
    };
    
    //map 1
    private float[,] wallPositionsMap1 =
    {
        {0f, -3.5f, 3.5f, -4.5f, 4.5f, -2.5f, 2.5f, -3.5f, 3.5f, 0f}, // x
        {3f, 1.8f, 1.8f, 0.81f, 0.81f, -0.81f, -0.81f, -1.8f, -1.8f, -3f}, // y
        {0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f}, // z
        {0f, 0f, 0f, 90f, 90f, 90f, 90f, 0f, 0f, 0f} // rotation
    };

    //map 2
    private float[,] wallPositionsMap2 =
    {
        {0f, -3.2f, 3.2f, -4.5f, 4.5f, -3.2f, 3.2f, 0f}, // x
        {4.5f, 3.2f, 3.2f, 0f, 0f, -3.2f, -3.2f, -4.5f}, // y
        {0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f}, // z
        {0f, 45f, -45f, 90f, 90f, -45f, 45f, 0f} // rotation
    };

    //map 3
    private float[,] wallPositionsMap3 =
    {
        { 0f, 0f, -5f, 5f, 0f, 0f }, //x
        { 3f, 1f, 0f, 0f, -1f, -3f }, //y
        { 0f, 0f, 0f, 0f, 0f, 0f}, //z
        { 90f, 90f, 90f, 90f, 90f, 90f} // rotation
    };

    
    //-------------------- power up spawner positions --------------------

    // map 0
    private float[,] powerUpSpawnerPositionsMap0 =
    {
        {0f, -1f, 1f, 0f}, // x
        {1f, 0f, 0f, -1f}, // y
        {0f, 0f, 0f, 0f}, // z
        {0f, 0f, 0f, 0f} // rotation
    };
    
    // map 1
    private float[,] powerUpSpawnerPositionsMap1 =
    {
        {-1f, 1f, -1f, 1f}, // x
        {1f, 1f, -1f, -1f}, // y
        {0f, 0f, 0f, 0f}, // z
        {0f, 0f, 0f, 0f} // rotation
    };
    
    // map 2
    private float[,] powerUpSpawnerPositionsMap2 =
    {
        {-1f, 1f, -1f, 1f}, // x
        {1f, 1f, -1f, -1f}, // y
        {0f, 0f, 0f, 0f}, // z
        {0f, 0f, 0f, 0f} // rotation
    };
    
    // map 3
    private float[,] powerUpSpawnerPositionsMap3 =
    {
        {0f, 0f}, // x
        {4.5f, -4.5f}, // y
        {0f, 0f}, // z
        {0f, 0f} // rotation
    };
    
    //-------------------- Player positions --------------------
    
    // map 1
    private float[,] playerPositionsMap0 =
    {
        {-3.5f, 3.5f},
        {-2f, 1.5f},
        {0.5f, 0.5f},
        {0f, 180f}
    };
    
    // map 1
    private float[,] playerPositionsMap1 =
    {
        {-6f, 6f},
        {0f, 0f},
        {0.5f, 0.5f},
        {270f, 90f}
    };
    
    // map 1
    private float[,] playerPositionsMap2 =
    {
        {-6f, 6f},
        {0f, 0f},
        {0.5f, 0.5f},
        {270f, 90f}
    };
    
    // map 3
    private float[,] playerPositionsMap3 =
    {
        {-6f, 6f},
        {0f, 0f},
        {0.5f, 0.5f},
        {270f, 90f}
    };



    
    public void Generate(int map)
    {
        switch (map)
        {
            case 0:
                place(wallPrefab, wallPositionsMap0);
                place(powerUpSpawner, powerUpSpawnerPositionsMap0);
                placePlayers(playerPositionsMap0);
                break;
            case 1:
                place(wallPrefab, wallPositionsMap1);
                place(powerUpSpawner, powerUpSpawnerPositionsMap1);
                placePlayers(playerPositionsMap1);
                break;
            case 2:
                place(wallPrefab, wallPositionsMap2);
                place(powerUpSpawner, powerUpSpawnerPositionsMap2);
                placePlayers(playerPositionsMap2);
                break;
            case 3:
                place(wallPrefab, wallPositionsMap3);
                place(powerUpSpawner, powerUpSpawnerPositionsMap3);
                placePlayers(playerPositionsMap3);
                break;
        }
    }

    private void place(GameObject prefab, float[,] buildPositions)
    {
        for (int block = 0; block < buildPositions.GetLength(1); block++)
        {
            float x = buildPositions[0, block];
            float y = buildPositions[1, block];
            float z = buildPositions[2, block];
            float rotation = buildPositions[3, block];

            Instantiate(prefab, new Vector3(x, y, z), Quaternion.Euler(0f, 0f, rotation));
        }
    }
    
    private void placePlayers(float[,] buildPositions)
    {
        for (int player = 0; player < buildPositions.GetLength(1); player++)
        {
            float x = buildPositions[0, player];
            float y = buildPositions[1, player];
            float z = buildPositions[2, player];
            float rotation = buildPositions[3, player];

            switch (player)
            {
                case 0:
                    displayManager.Player1 = Instantiate(greenPlayer, new Vector3(x, y, z), Quaternion.Euler(0f, 0f, rotation)).GetComponent<BaseMovement>();
                    break;
                case 1:
                    displayManager.Player2 = Instantiate(yellowPlayer, new Vector3(x, y, z), Quaternion.Euler(0f, 0f, rotation)).GetComponent<BaseMovement>();
                    break;
            }
        }
    }
    
    void Start()
    {
        Generate(1);
    }
}
