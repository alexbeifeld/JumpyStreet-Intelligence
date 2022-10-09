using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Transform movePoint;
    void Start()
    {
        movePoint.parent = null;
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
            }
        }


        RaycastHit2D hitDown = Physics2D.Raycast(transform.position, -transform.up, 1f);
        RaycastHit2D hitUp = Physics2D.Raycast(transform.position, transform.up, 1f);
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, -transform.right, 1f);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, transform.right, 1f);

        if(hitDown.collider != null)
        {
            if (hitDown.collider.name != "Player")
            {
                Debug.Log(hitDown.collider.name);
            }
        }

        if (hitUp.collider != null)
        {
            if (hitUp.collider.name != "Player")
            {
                Debug.Log(hitUp.collider.name);
            }
        }

        if (hitLeft.collider != null)
        {
            if (hitLeft.collider.name != "Player")
            {
                Debug.Log(hitLeft.collider.name);
            }
        }

        if (hitRight.collider != null)
        {
            if (hitRight.collider.name != "Player")
            {
                Debug.Log(hitRight.collider.name);
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            Debug.Log("You died");
            FrogDeath();
            //Trigger death by water
        }
        if (other.gameObject.CompareTag("Log"))
        {
            transform.parent = other.gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Log"))
        {
            transform.parent = null;
        }
    }

    private void FrogDeath()
    {
        //Handles frog dying
        gameObject.SetActive(false);
    }
}
