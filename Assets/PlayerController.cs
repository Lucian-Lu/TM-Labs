using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movSpeed;
    float moveX, moveY;
    Rigidbody2D rb;
    private Vector2 moveDirection;
    bool facingRight = true;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;

        rb.velocity = new Vector2(moveDirection.x * movSpeed, moveDirection.y * movSpeed);
        if (moveX != 0){
            animator.SetFloat("Speed", Mathf.Abs(moveX));
        } else if (moveY != 0)
        {
            animator.SetFloat("Speed", Mathf.Abs(moveY));
        } else 
        {
            animator.SetFloat("Speed", Mathf.Abs(0));
        }

        if (moveX > 0 && !facingRight)
        {
            Flip();
        }
        if (moveX < 0 && facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}
