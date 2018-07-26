using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [Range(1, 10)]
    public float jumpVelocity, fallMultiplier;
    public GameObject gameControllerObject;
    public LayerMask groundLayer;

    private GameController gameController;
    private Rigidbody2D rb;
    private bool gameOver;

    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1.5f;
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameOver = false;
    }
    void Start()
    {
        gameController = gameControllerObject.GetComponent<GameController>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() && !gameOver)
        {
            rb.velocity = Vector2.up * jumpVelocity;
            gameController.AddScore(10);
        }
        if(rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * fallMultiplier * Time.deltaTime;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Swing")
        {
            rb.freezeRotation = false;
            gameController.GameOver();
            gameOver = true;
        }
    }
}
