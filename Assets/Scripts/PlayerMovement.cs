using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Transform movePoint;

    [SerializeField] private bool onLog = false;
    [SerializeField] private bool noLeft = false;
    [SerializeField] private bool noRight = false;
    [SerializeField] private bool noUp = false;
    [SerializeField] private bool noDown = false;

    void Start()
    {
        movePoint.parent = null;
    }

    void FixedUpdate()
    {
        RaycastHit2D hitDown = Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y - .5f), -transform.up, 11f);
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y - .5f), -transform.up, Color.red);
        RaycastHit2D hitUp = Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y + .5f), Vector2.up, 11f);
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + .5f), transform.up, Color.red);
        RaycastHit2D hitLeft = Physics2D.Raycast(new Vector3(transform.position.x - .5f, transform.position.y), -transform.right, 11f);
        Debug.DrawRay(new Vector3(transform.position.x - .5f, transform.position.y), -transform.right, Color.red);
        RaycastHit2D hitRight = Physics2D.Raycast(new Vector3(transform.position.x + .5f, transform.position.y), transform.right, 11f);
        Debug.DrawRay(new Vector3(transform.position.x + .5f, transform.position.y), transform.right, Color.red);

        if (hitDown.collider != null)
        {
            if (hitDown.collider.name != "Player")
            {
                //Debug.Log(hitDown.collider.name);
            }
            if (hitDown.collider.CompareTag("Tree"))
            {
                noDown = true;
            }
            else
            {
                noDown = false;
            }
            if (hitDown.collider.CompareTag("Water"))
            {
                Collider2D waterCollider = hitDown.collider;
                if (hitDown.collider.CompareTag("Log"))
                {
                    onLog = true;
                    Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), waterCollider);
                }
                else
                {
                    onLog = false;
                }
            }
        }

        if (hitUp.collider != null)
        {
            if (hitUp.collider.name != "Player")
            {
                Debug.Log(hitUp.collider.name);
            }
            if (hitUp.collider.CompareTag("Tree"))
            {
                noUp = true;
            }
            else
            {
                noUp = false;
            }
            if (hitUp.collider.CompareTag("Water"))
            {
                Debug.Log("Water ahead");
                Collider2D waterCollider = hitUp.collider;
                if (hitUp.collider.CompareTag("Log"))
                {
                    onLog = true;
                    Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), waterCollider);
                }
                else
                {
                    onLog = false;
                }
            }
        }

        if (hitLeft.collider != null)
        {
            if (hitLeft.collider.name != "Player")
            {
                //Debug.Log(hitLeft.collider.name);
            }
            if (hitLeft.collider.CompareTag("Tree"))
            {
                noLeft = true;
            }
            else
            {
                noLeft = false;
            }
        }

        if (hitRight.collider != null)
        {
            if (hitRight.collider.name != "Player")
            {
                //Debug.Log(hitRight.collider.name);
            }
            if (hitRight.collider.CompareTag("Tree"))
            {
                noRight = true;
            }
            else
            {
                noRight = false;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (Input.GetAxisRaw("Horizontal") == 1f)
            {
                if (!noRight)
                {
                    movePoint.position += new Vector3(1f, 0f, 0f);
                }
            }
            else if (Input.GetAxisRaw("Horizontal") == -1f)
            {
                if (!noLeft)
                {
                    movePoint.position += new Vector3(-1f, 0f, 0f);
                }
            }
            else if (Input.GetAxisRaw("Vertical") == 1f)
            {
                if (!noUp)
                {
                    movePoint.position += new Vector3(0f, 1f, 0f);
                }
            }
            else if (Input.GetAxisRaw("Vertical") == -1f)
            {
                if (!noDown)
                {
                    movePoint.position += new Vector3(0f, -1f, 0f);
                }
            }
        }


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Log"))
        {
            transform.parent = other.gameObject.transform;
        }
        if (other.gameObject.CompareTag("Water"))
        {
            if (!onLog)
            {
                Debug.Log("You died");
                //FrogDeath();
                //Trigger death by water
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Log"))
        {
            gameObject.transform.parent = null;
        }
    }

    private void FrogDeath()
    {
        //Handles frog dying
        gameObject.SetActive(false);
    }

}
