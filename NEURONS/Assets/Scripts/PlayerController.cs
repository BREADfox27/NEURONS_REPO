using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float life;
    public TextMeshProUGUI lifeText;
    
    private Rigidbody2D playerRb;
    private Animator anim;
    private float horizontalInput;
    private bool isFacingRight = true;

    [SerializeField] bool isGrounded;
    [SerializeField] GameObject groundCheck;
    [SerializeField] LayerMask groundLayer;

    public float speed;
    public float jumpForce;
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;
    
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

        if (horizontalInput > 0)
        {
            if (!isFacingRight)
            {
                FlipSprite();
            }
        }

        if (horizontalInput < 0)
        {
            if (isFacingRight)
            {
                FlipSprite();
            }
        }

        if (life == 0)
        {
            SceneManager.LoadScene("Lose");
        }

        if (life == 2)
        {

        }

        if (life == 1)
        {

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            life--;
            lifeText.text = "Lifes: " + life;
            Debug.Log("-1 life.");
        }
    }

    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        playerRb.linearVelocity = new Vector2 (horizontalInput * speed, playerRb.linearVelocity.y);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void FlipSprite()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
        isFacingRight = !isFacingRight;
    }
}
