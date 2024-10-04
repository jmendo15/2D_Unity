using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player's movement
    public float jumpForce = 10f; // Force applied when the player jumps
    public float descendMultiplier = 2f; // Multiplier for the descending speed
    public LayerMask groundLayer; // Layer mask to check if the player is grounded
    public Animator anim;

    private Rigidbody2D rb;
    private CapsuleCollider2D bodyCollider;
    private BoxCollider2D feetCollider;
    private bool isGrounded;
    private float moveInput;
    public SpriteRenderer mySpriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bodyCollider = GetComponent<CapsuleCollider2D>();
        feetCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Handle left and right movement
        moveInput = Input.GetAxisRaw("Horizontal"); // Use GetAxisRaw for instant response

        if (moveInput != 0)
        {
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        // Check if the player is grounded
        isGrounded = (Physics2D.IsTouchingLayers(feetCollider, groundLayer));

        // Handle jumping
            if (isGrounded && Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }

            // Handle faster descending
            if (!isGrounded && Input.GetAxis("Vertical") < 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y - descendMultiplier * Time.deltaTime);
            }

            // Update animations
            anim.SetBool("isRunning", moveInput != 0);
            anim.SetBool("isGrounded", isGrounded);
            anim.SetBool("isFalling", !isGrounded && rb.velocity.y < 0);

            if (moveInput > 0)
            {
                mySpriteRenderer.flipX = false;
            }
            else if (moveInput < 0)
            {
                mySpriteRenderer.flipX = true;
            }
        }
    }