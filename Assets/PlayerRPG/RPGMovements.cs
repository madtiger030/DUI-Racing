using UnityEngine;

public class RPGMovements : MonoBehaviour
{
 
    public float speed = 10f;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input from WASD keys
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Normalize diagonal movement to prevent faster diagonal speed
        movement = movement.normalized;
    }

    void FixedUpdate()
    {
        // Apply movement using physics
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}

