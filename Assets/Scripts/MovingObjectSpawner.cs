using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjectSpawner : MonoBehaviour
{

    [SerializeField] private GameObject prefabToSpawn;
    private Vector3 spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = new Vector3(11, gameObject.transform.position.y, -6);
        InvokeRepeating("SpawnObject", 1, 3.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnObject()
    {
        GameObject go = Instantiate(prefabToSpawn, spawnPoint, Quaternion.identity);
        go.transform.parent = gameObject.transform;
    }
}
