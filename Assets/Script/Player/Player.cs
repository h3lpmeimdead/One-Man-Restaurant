using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public Joystick movementJoystick;
    public float playerSpeed;
    private Rigidbody2D rb;
    public int catID;
    public SpriteRenderer spriteRenderer;
    public float rayDistance = 2f;

    //public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(movementJoystick.joystickVec.y != 0)
        {
            rb.velocity = new Vector2(movementJoystick.joystickVec.x * playerSpeed, movementJoystick.joystickVec.y * playerSpeed);
        }
        else
        {
            rb.velocity = Vector2.zero;
            //animator.SetTrigger("still");
        }
    }

    public void ShootingRaycast()
    {
        // Define the four directions
        Vector2[] directions = new Vector2[]
        {
            Vector2.up,
            Vector2.down,
            Vector2.left,
            Vector2.right
        };

        // Shoot raycasts in each direction
        foreach (Vector2 direction in directions)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, rayDistance);

            if (hit.collider != null)
            {
                //Debug.Log("Hit " + hit.collider.name);
                // Perform actions when an object is hit
            }

            // For visualization in the Scene view
            Debug.DrawRay(transform.position, direction * rayDistance, Color.red);
        }
    }
}
