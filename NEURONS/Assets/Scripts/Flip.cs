using UnityEngine;

public class Flip : MonoBehaviour
{
    PlayerController playerController;

    private float horizontalInput;
    private bool isFacingRight = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
    }

    void FlipSprite()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
        isFacingRight = !isFacingRight;
    }
}
