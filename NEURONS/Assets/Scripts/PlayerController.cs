using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float life;

    [Header("Player Configuration")]
    private Rigidbody2D playerRb;
    private Animator anim;
    private float horizontalInput;
    private bool isFacingRight = true;
    public float speed;
    public float jumpForce;
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;

    [Header("GroundCheck Configuration")]
    [SerializeField] bool isGrounded;
    [SerializeField] GameObject groundCheck;
    [SerializeField] LayerMask groundLayer;

    [Header("Respawn Configuration")]
    [SerializeField] Transform respawnPoint;

    [Header("DeadBody Configuration")]
    public GameObject keyToPress;
    public GameObject deadBody1;
    public GameObject deadBody2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        life1.gameObject.SetActive(true);
        life2.gameObject.SetActive(false);
        life3.gameObject.SetActive(false);
        keyToPress.gameObject.SetActive(false);
        deadBody1.gameObject.SetActive(false);
        deadBody2.gameObject.SetActive(true);
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
            life3.gameObject.SetActive(false);
            SceneManager.LoadScene("Lose");
        }

        if (life == 2)
        {
            life1.gameObject.SetActive(false);
            life2.gameObject.SetActive(true);
        }

        if (life == 1)
        {
            life2.gameObject.SetActive(false);
            life3.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            life--;
            AudioManager.Instance.PlaySFX(0);
            Respawn();
            other.gameObject.SetActive(true);
            Debug.Log("-1 life.");
        }

        if (other.gameObject.CompareTag("Brain"))
        {
            SceneManager.LoadScene("BrainScene");
        }

        if (other.gameObject.CompareTag("Arrow"))
        {
            keyToPress.gameObject.SetActive(true);
        }

        if (other.gameObject.CompareTag("EnergyBall"))
        {
            transform.position = new Vector2(transform.position.x + 10f, transform.position.y + 1f);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            keyToPress.gameObject.SetActive(false);
        }
    }

    void Respawn()
    {
        transform.position = respawnPoint.position;
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

    public void WalkingSound()
    {
        AudioManager.Instance.PlaySFX(1);
    }

    public void Teleportation()
    {

    }
}
