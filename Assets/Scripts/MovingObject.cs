using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyAfterTime(6f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.right * speed * Time.deltaTime;
    }

    private IEnumerator DestroyAfterTime(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
