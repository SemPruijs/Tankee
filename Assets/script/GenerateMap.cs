using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class GenerateMap : MonoBehaviour
{
    //-------------------- Prefabs --------------------
    public GameObject wallPrefab;
    public GameObject powerUpSpawner;

    //-------------------- wall positions --------------------
    
    //map 0
    private float[,] wallPositionsMap0 =
    {
        {-3.5f, 3.5f, -2.5f, 2.5f, -2.5f, 2.5f, -3.5f, 3.5f}, // x
        {3f, 3f, 2f, 2f, -2f, -2f, -3f, -3f}, // y
        {0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f}, // z
        {0f, 0f, 90f, 90f, 90f, 90f, 0f, 0f} // rotation
    };
    
    private float[,] wallPositionsMap1 =
    {
        {0f, -3.5f, 3.5f, -4.5f, 4.5f, -2.5f, 2.5f, -3.5f, 3.5f, 0f}, // x
        {3f, 1.8f, 1.8f, 0.81f, 0.81f, -0.81f, -0.81f, -1.8f, -1.8f, -3f}, // y
        {0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f}, // z
        {0f, 0f, 0f, 90f, 90f, 90f, 90f, 0f, 0f, 0f} // rotation
    };

    private float[,] wallPositionsMap2 =
    {
        {0f, -3.2f, 3.2f, -4.5f, 4.5f, -3.2f, 3.2f, 0f}, // x
        {4.5f, 3.2f, 3.2f, 0f, 0f, -3.2f, -3.2f, -4.5f}, // y
        {0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f}, // z
        {0f, 45f, -45f, 90f, 90f, -45f, 45f, 0f} // rotation
    };

    
    //-------------------- power up spawner positions --------------------

    private float[,] powerUpSpawnerPositionsMap0 =
    {
        {0f, -1f, 1f, 0f}, // x
        {1f, 0f, 0f, -1f}, // y
        {0f, 0f, 0f, 0f}, // z
        {0f, 0f, 0f, 0f} // rotation
    };
    
    private float[,] powerUpSpawnerPositionsMap1 =
    {
        {-1f, 1f, -1f, 1f}, // x
        {1f, 1f, -1f, -1f}, // y
        {0f, 0f, 0f, 0f}, // z
        {0f, 0f, 0f, 0f} // rotation
    };
    
    private float[,] powerUpSpawnerPositionsMap2 =
    {
        {-1f, 1f, -1f, 1f}, // x
        {1f, 1f, -1f, -1f}, // y
        {0f, 0f, 0f, 0f}, // z
        {0f, 0f, 0f, 0f} // rotation
    };

    
    
    
    
    
    public void Generate(int map)
    {
        switch (map)
        {
            case 0:
                place(wallPrefab, wallPositionsMap0);
                place(powerUpSpawner, powerUpSpawnerPositionsMap0);
                break;
            case 1:
                place(wallPrefab, wallPositionsMap1);
                place(powerUpSpawner, powerUpSpawnerPositionsMap1);
                break;
            case 2:
                place(wallPrefab, wallPositionsMap2);
                place(powerUpSpawner, powerUpSpawnerPositionsMap2);
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

    void Start()
    {
        Generate(2);
    }
}
