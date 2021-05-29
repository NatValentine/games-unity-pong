using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 30;
    private Vector2 initialPosition;
    private Rigidbody2D rb;

    void Start()
    {
        initialPosition = GetComponent<Transform>().position;
        rb = GetComponent<Rigidbody2D>();

        // Initial Velocity
        rb.velocity = Vector2.right * speed;
    }

    float hitFactor(Vector2 ballPos, Vector2 playerPos, float playerHeight)
    {
        // ||  1 <- at the top 
        // ||
        // ||  0 <- at the middle
        // ||
        // || -1 <- at the bottom
        return (ballPos.y - playerPos.y) / playerHeight;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Note: 'col' holds the collision information. If the ball was hit by a player, then:
        //   col.gameObject is the player
        //   col.transform.position is the player's position
        //   col.collider is the player's collider

        if(col.gameObject.GetComponent<PlayerController>())
        {
            // Calculate hit Factor
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            float dirX = 0;
            if (col.transform.position.x > 0) dirX = -1; else dirX = 1;
            Vector2 direction = new Vector2(dirX, y).normalized;

            // Set Velocity with dir * speed
            rb.velocity = direction * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Depending on the ball position it collided with one goal or the other. Update the score accordingly.
        if (gameObject.transform.position.x > 0) GameController.instance.UpdateScore(1); else GameController.instance.UpdateScore(2);

        gameObject.GetComponent<AudioSource>().Play(0);

        gameObject.transform.position = initialPosition;
        rb.velocity = Vector2.right * speed;
    }
}
