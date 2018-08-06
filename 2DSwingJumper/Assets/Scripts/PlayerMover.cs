using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [Header("Jump")]
    public LayerMask groundLayer;
    public float groundDistance = 1.5f;
    [Range(1, 10)]
    public float jumpVelocity, fallMultiplier;

    [Header("References")]
    public GameObject gameControllerObject;
    public Animator playerAnimator;

    private GameController gameController;
    private Rigidbody2D rb;
    private bool gameOver;

    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        RaycastHit2D hit = Physics2D.Raycast(position, direction, groundDistance, groundLayer);
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
            gameController.AddScore(1);
            playerAnimator.Play("Jump");
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
            playerAnimator.Play("Death");
            gameController.GameOver();
            gameOver = true;
        }
    }
}
