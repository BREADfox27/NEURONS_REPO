using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    PlayerController playerController;
    
    private Rigidbody2D playerRb;
    private Animator anim;
    private float horizontalInput;

    [SerializeField] bool isGrounded;
    [SerializeField] GameObject groundCheck;
    [SerializeField] LayerMask groundLayer;

    public float speed;
    public float jumpForce;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, 0.1f, groundLayer);
        Movement();
        Jump();
    }

    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        playerRb.linearVelocity = new Vector2 (horizontalInput * speed, playerRb.linearVelocity.y);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
