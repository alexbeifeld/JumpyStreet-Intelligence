using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjectSpawner : MonoBehaviour
{

    [SerializeField] private GameObject prefabToSpawn;
    private Vector3 spawnPoint;

    [Header("Spawn Timer")]
    [Space(10)]
    [SerializeField] private int minTimeSpawn;
    [SerializeField] private int maxTimeSpawn;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = new Vector3(11, gameObject.transform.position.y, 0);
        StartCoroutine(SpawnOnInterval());
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

    private IEnumerator SpawnOnInterval()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minTimeSpawn, maxTimeSpawn + 1));
            SpawnObject();
        }
    }
}
