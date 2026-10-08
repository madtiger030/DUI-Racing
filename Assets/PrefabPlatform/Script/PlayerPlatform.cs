using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatform : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 8f;
    public float groundAcceleration = 20f;
    public float airAcceleration = 10f;
    public float groundDeceleration = 25f;
    public float airDeceleration = 15f;

    [Header("Jump Settings")]
    public float jumpForce = 16f;
    public float jumpCutMultiplier = 0.5f; // Reduce jump height when button released early
    public float fallMultiplier = 2.5f; // Makes falling faster
    public float lowJumpMultiplier = 2f; // Makes low jumps more controlled

    [Header("Ground Detection")]
    public Transform groundCheck;
    public float groundCheckDistance = 0.2f;
    public string groundTag = "Ground";

    [Header("Visuals")]
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    // Private variables
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isFacingRight = true;
    private float horizontalInput;
    private bool isJumping;

    // Animation parameters
    private static readonly int IsRunning = Animator.StringToHash("isRunning");
    private static readonly int IsGrounded = Animator.StringToHash("isGrounded");
    private static readonly int VerticalVelocity = Animator.StringToHash("verticalVelocity");

    void Start()
    {
        // Get references to components
        rb = GetComponent<Rigidbody2D>();

        // If no sprite renderer is assigned, try to get it from the object
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        // If no animator is assigned, try to get it from the object
        if (animator == null)
            animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Get input
        horizontalInput = Input.GetAxisRaw("Horizontal");

        // Check for jump input
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }

        // Better jump control - cut jump short if button released
        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * jumpCutMultiplier);
        }

        // Update animations
        UpdateAnimations();
    }

    void FixedUpdate()
    {
        // Check if player is grounded
        CheckGrounded();

        // Handle movement
        Move();

        // Handle jumping
        HandleJump();

        // Apply better gravity for less floaty feel
        ApplyBetterGravity();
    }

    void Move()
    {
        float targetSpeed = horizontalInput * moveSpeed;
        float speedDiff = targetSpeed - rb.linearVelocity.x;
        float accelerationRate = (Mathf.Abs(targetSpeed) > 0.01f) ?
            (isGrounded ? groundAcceleration : airAcceleration) :
            (isGrounded ? groundDeceleration : airDeceleration);

        float movement = speedDiff * accelerationRate;

        // Apply force for movement
        rb.AddForce(movement * Vector2.right);

        // Flip character sprite if needed
        if ((horizontalInput > 0 && !isFacingRight) || (horizontalInput < 0 && isFacingRight))
        {
            Flip();
        }
    }

    void HandleJump()
    {
        if (isJumping)
        {
            // Apply jump force
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isJumping = false;
        }
    }

    void ApplyBetterGravity()
    {
        // Makes jumping feel less floaty
        if (rb.linearVelocity.y < 0)
        {
            // Falling down - apply fall multiplier
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
        }
        else if (rb.linearVelocity.y > 0 && !Input.GetButton("Jump"))
        {
            // Jump button released early - apply low jump multiplier
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.fixedDeltaTime;
        }
    }

    void CheckGrounded()
    {
        // Use multiple raycasts for better detection
        float raycastSpacing = 0.1f;
        int rays = 3; // Number of rays to cast

        bool wasGrounded = isGrounded;
        isGrounded = false;

        for (int i = 0; i < rays; i++)
        {
            float offset = (i - (rays - 1) / 2f) * raycastSpacing;
            Vector2 origin = new Vector2(groundCheck.position.x + offset, groundCheck.position.y);

            RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, groundCheckDistance);

            // Visualize the rays in the editor
            Debug.DrawRay(origin, Vector2.down * groundCheckDistance, Color.red);

            if (hit.collider != null && hit.collider.CompareTag(groundTag))
            {
                isGrounded = true;
                break;
            }
        }
    }

    void Flip()
    {
        // Switch the way the player is labelled as facing
        isFacingRight = !isFacingRight;

        // Multiply the player's x local scale by -1 to flip
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void UpdateAnimations()
    {
        // Update animator parameters
        if (animator != null)
        {
            animator.SetBool(IsRunning, Mathf.Abs(horizontalInput) > 0.1f);
            animator.SetBool(IsGrounded, isGrounded);
            animator.SetFloat(VerticalVelocity, rb.linearVelocity.y);
        }
    }

    // Visualize ground check in editor
    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = isGrounded ? Color.green : Color.red;
            Gizmos.DrawLine(groundCheck.position, groundCheck.position + Vector3.down * groundCheckDistance);
            Gizmos.DrawWireSphere(groundCheck.position + Vector3.down * groundCheckDistance, 0.02f);
        }
    }
}
