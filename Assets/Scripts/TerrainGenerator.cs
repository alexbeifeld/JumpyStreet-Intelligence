using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{

    [SerializeField] private int maxTerrainCount;
    [SerializeField] private List<GameObject> terrains = new List<GameObject>();

    //How big the chunks of each terrain should be generated;
    [Header("Terrain Sizes")]
    [Space(10)]
    [SerializeField] private int grassMinSpawned;
    [SerializeField] private int grassMaxSpawned;
    [Space(10)]
    [SerializeField] private int roadMinSpawned;
    [SerializeField] private int roadMaxSpawned;
    [Space(10)]
    [SerializeField] private int waterMinSpawned;
    [SerializeField] private int waterMaxSpawned;
    //Starting positions that updates as new terrains are being created along the y axis.
    private Vector2 currentPosition = new Vector2(0, 4.5f);
    [Space(10)]
    //List of the terrains being generated (will be used to delete when off screen)
    [SerializeField] private List<GameObject> currentTerrains = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        SpawnTerrain();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            SpawnTerrain();
        }
    }

    private void SpawnTerrain()
    {
        GenerateTerrain(Random.Range(0, 3));
        int lastIndex = currentTerrains.Count - 1;
        if (currentTerrains[lastIndex].CompareTag("Grass"))
        {
            Debug.Log("Inside Grass");
            lastIndex--;
            if (!currentTerrains[lastIndex].CompareTag("Grass"))
            {
                Debug.Log("Generating more grass");
                for (int i = 0; i < Random.Range(grassMinSpawned, grassMaxSpawned + 1); i++)
                {
                    GenerateTerrain(0);
                }
            }
        }       
        
        else if (currentTerrains[lastIndex].CompareTag("Road"))
        {
            lastIndex--;
            if (!currentTerrains[lastIndex].CompareTag("Road"))
            {
                Debug.Log("Generating more road");
                for (int i = 0; i < Random.Range(grassMinSpawned, grassMaxSpawned + 1); i++)
                {
                    GenerateTerrain(1);
                }
            }
        }      
        
        else if (currentTerrains[lastIndex].CompareTag("Water"))
        {
            lastIndex--;
            if (!currentTerrains[lastIndex].CompareTag("Water"))
            {
                Debug.Log("Generating more road");
                for (int i = 0; i < Random.Range(grassMinSpawned, grassMaxSpawned + 1); i++)
                {
                    GenerateTerrain(2);
                }
            }
        }

        else
        {
            GenerateTerrain(Random.Range(0, 3));
            Debug.Log("Generating something new");
        }
    }

    //Spawns terrain at the current position from the list that holds the different types of terrains and stores it in another list.
    private void GenerateTerrain(int index)
    {
        GameObject terrain = Instantiate(terrains[index], currentPosition, Quaternion.identity);
        currentTerrains.Add(terrain);
        currentPosition.y++;
        //Deletes the terrain when there is enough terrain to cover the screen.
        if (currentTerrains.Count > maxTerrainCount)
        {
            Destroy(currentTerrains[0]);
            currentTerrains.RemoveAt(0);
        }
    }
}
