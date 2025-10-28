using UnityEngine;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour
{

    public Rigidbody2D rb;
    private float speed = 10f;
    private float jumpStrength = 25f;
    private float jumpHoldForce = 75f;      // Extra upward force while holding
    private float maxJumpHoldTime = 0.2f;  // Max time extra force can be applied
    public Transform groundCheck;
    public LayerMask groundLayer;
    private float groundCheckRadius = 0.1f;

    bool isGrounded;
    private bool isJumping;
    private float jumpTimeCounter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Check if grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Horizontal movement
        float moveX = 0f;
        if (Input.GetKey(KeyCode.D)) moveX = 1f;
        if (Input.GetKey(KeyCode.A)) moveX = -1f;
        rb.linearVelocity = new Vector2(moveX * speed, rb.linearVelocity.y);

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpStrength);
            isJumping = true;
            jumpTimeCounter = 0f;
        }

        // Variable height while holding jump
        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            if (jumpTimeCounter < maxJumpHoldTime)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y + jumpHoldForce * Time.deltaTime);
                jumpTimeCounter += Time.deltaTime;
            }
        }

        // Stop extra jump when released
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }
}
