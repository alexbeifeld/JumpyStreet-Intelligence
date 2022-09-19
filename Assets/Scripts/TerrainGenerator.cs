using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{

    [SerializeField] private int maxTerrainCount;
    [SerializeField] private List<GameObject> terrains = new List<GameObject>();

    //Starting positions that updates as new terrains are being created along the y axis.
    private Vector2 currentPosition = new Vector2(0, -5);
    //List of the terrains being generated (will be used to delete when off screen)
    private List<GameObject> currentTerrains = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        SpawnTerrain();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            SpawnTerrain();
        }
    }

    //Spawns terrain at the current position from the list that holds the different types of terrains and stores it in another list.
    private void SpawnTerrain()
    {
        GameObject terrain = Instantiate(terrains[Random.Range(0, terrains.Count)], currentPosition, Quaternion.identity);
        currentTerrains.Add(terrain);
        if(currentTerrains.Count > maxTerrainCount)
        {
            Destroy(currentTerrains[0]);
            currentTerrains.RemoveAt(0);
        }
        currentPosition.y++;
    }
}
