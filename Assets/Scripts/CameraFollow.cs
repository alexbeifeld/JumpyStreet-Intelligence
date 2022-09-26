using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //
    //Script is meant to allow the camera to follow the player once they cross
    //a threshold and will mostly be used in 2d games.
    //
    [SerializeField] private GameObject followObject;
    [SerializeField] private Vector2 followOffset;
    [SerializeField] private float speed = 5.0f;
    private Vector2 threshold;
    void Start()
    {
        threshold = calculateThreshold();
    }

    void FixedUpdate()
    {
        Vector2 follow = followObject.transform.position;
        float xDifference = Vector2.Distance(Vector2.right * transform.position.x, Vector2.right * follow.x);
        float yDifference = Vector2.Distance(Vector2.up * transform.position.y, Vector2.up * follow.y);

        Vector3 newPosition = transform.position;
        if (Mathf.Abs(xDifference) >= threshold.x)
        {
            newPosition.x = follow.x;
        }
        if (Mathf.Abs(yDifference) >= threshold.y)
        {
            newPosition.y = follow.y;
        }
        transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
    }
    private Vector3 calculateThreshold()
    {
        Rect aspect = Camera.main.pixelRect;
        Vector2 screenSize = new Vector2(Camera.main.orthographicSize * aspect.width / aspect.height, Camera.main.orthographicSize);
        screenSize.x -= followOffset.x;
        screenSize.y -= followOffset.y;
        return screenSize;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector2 border = calculateThreshold();
        Gizmos.DrawWireCube(transform.position, new Vector3(border.x * 2, border.y * 2, 1));
    }
}
