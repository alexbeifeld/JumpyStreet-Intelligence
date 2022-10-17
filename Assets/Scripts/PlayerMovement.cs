using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Transform movePoint;
    [SerializeField] private GameObject gameOverPanel;

    [SerializeField] private bool onLog = false;
    [SerializeField] private bool noLeft = false;
    [SerializeField] private bool noRight = false;
    [SerializeField] private bool noUp = false;
    [SerializeField] private bool noDown = false;

    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text gameOverText;
    private int score;

    private AudioSource playerMove;
    void Start()
    {
        gameOverPanel.SetActive(false);
        movePoint.parent = null;
        playerMove = GetComponent<AudioSource>();
        scoreText.text = "0 m";
    }

    private void Update()
    {
        CheckBounds();

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (Input.GetAxisRaw("Horizontal") == 1f)
            {
                if (!noRight)
                {
                    movePoint.position += new Vector3(1f, 0f, 0f);
                    playerMove.Play();
                }
            }
            else if (Input.GetAxisRaw("Horizontal") == -1f)
            {
                if (!noLeft)
                {
                    movePoint.position += new Vector3(-1f, 0f, 0f);
                    playerMove.Play();
                }
            }
            else if (Input.GetAxisRaw("Vertical") == 1f)
            {
                if (!noUp)
                {
                    movePoint.position += new Vector3(0f, 1f, 0f);
                    playerMove.Play();
                    score++;
                }
            }
            else if (Input.GetAxisRaw("Vertical") == -1f)
            {
                if (!noDown)
                {
                    movePoint.position += new Vector3(0f, -1f, 0f);
                    playerMove.Play();
                    score--;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        scoreText.text = score.ToString() + " m";
        RaycastHit2D hitDown = Physics2D.Raycast(new Vector3(movePoint.transform.position.x, movePoint.transform.position.y - .5f), -Vector2.up, 11);
        Debug.DrawRay(new Vector3(movePoint.transform.position.x, movePoint.transform.position.y - .5f), -Vector2.up, Color.red);
        RaycastHit2D hitUp = Physics2D.Raycast(new Vector3(movePoint.transform.position.x, movePoint.transform.position.y + .5f), Vector2.up, 11);
        Debug.DrawRay(new Vector3(movePoint.transform.position.x, movePoint.transform.position.y + .5f), Vector2.up, Color.red);
        RaycastHit2D hitLeft = Physics2D.Raycast(new Vector3(movePoint.transform.position.x - .5f, movePoint.transform.position.y), -Vector2.right, 11);
        Debug.DrawRay(new Vector3(movePoint.transform.position.x - .5f, movePoint.transform.position.y), -Vector2.right, Color.red);
        RaycastHit2D hitRight = Physics2D.Raycast(new Vector3(movePoint.transform.position.x + .5f, movePoint.transform.position.y), Vector2.right, 11);
        Debug.DrawRay(new Vector3(movePoint.transform.position.x + .5f, movePoint.transform.position.y), Vector2.right, Color.red);

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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Log"))
        {
            onLog = true;
            movePoint.transform.SetParent(other.transform);
        }
        if (other.gameObject.CompareTag("Water"))
        {
            if (!onLog)
            {
                Debug.Log("You died by water");
                FrogDeath();
                //Trigger death by water
            }
        }
        if (other.gameObject.CompareTag("Car"))
        {
            Debug.Log("You died by car");
            FrogDeath();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            if (!onLog)
            {
                Debug.Log("You died by water");
                FrogDeath();
                //Trigger death by water
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Log"))
        {
            movePoint.transform.SetParent(null);
            onLog = false;
            PlayerXPositionCorrection();
        }
    }

    private void FrogDeath()
    {
        //Handles frog dying
        gameObject.SetActive(false);
        gameOverPanel.SetActive(true);
        gameOverText.text = "Congradulations you made it " + score + " m";
    }

    private void PlayerXPositionCorrection()
    {
        Debug.Log("Correcting x position");
        transform.position = new Vector2(Mathf.Round(transform.position.x), transform.position.y);
    }

    private void CheckBounds()
    {
        //&& movePoint.position.x - 1 != -7 && movePoint.position.x + 1 != 7 && movePoint.position.y - 1 != -5)

        if (movePoint.position.x - 1 <= -7)
        {
            noLeft = true;
        }
        if (movePoint.position.x + 1 >= 7)
        {
            noRight = true;
        }
        if (movePoint.position.y - 1 <= -5)
        {
            noDown = true;
        }
    }
}
