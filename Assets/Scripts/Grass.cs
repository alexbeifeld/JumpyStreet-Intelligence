using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    [SerializeField] private GameObject treePrefab;

    [SerializeField] private List<Vector2> spawnLocations = new List<Vector2>();

    [Header("Number of trees to spawn (random)")]
    [SerializeField] private int minTreeSpawn;
    [SerializeField] private int maxTreeSpawn;

    [SerializeField] private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        SpawnTrees();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnTrees()
    {
        FindPlayerAndRemoveSpawn();
        for (int i = 0; i < Random.Range(minTreeSpawn, maxTreeSpawn + 1); i ++)
        {
            int spawnXIndex = Random.Range(0, spawnLocations.Count);
            GameObject newTree = Instantiate(treePrefab, new Vector3(spawnLocations[spawnXIndex].x, gameObject.transform.position.y+.5f, 0), Quaternion.identity);
            newTree.transform.parent = gameObject.transform;
            newTree.GetComponent<SpriteRenderer>().sortingOrder = 5;
            spawnLocations.RemoveAt(spawnXIndex);
        }
    }

    private void FindPlayerAndRemoveSpawn()
    {
        player = GameObject.Find("Player");
        if (player.transform.position.y == transform.position.y)
        {
            for (int i = 0; i < spawnLocations.Count; i++)
            {
                //Debug.Log("in loop");
                if(spawnLocations[i].x == player.transform.position.x)
                {
                    spawnLocations.RemoveAt(i);
                    Debug.Log("Removed position x: " + i + "y: " + transform.position.y);
                }    
            }
        }
    }
}
