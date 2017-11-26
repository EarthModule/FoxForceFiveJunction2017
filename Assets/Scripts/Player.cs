using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public int requestedDirection;
    public float Speed = 1f;
    public float JumpForce = 10f;
    public float Gravity = 20f;

    public int LeftClicked { get; set; }

    public int RightClicked { get; set; }
    bool shouldJump;
    bool grounded;


    private Animator animator;
    private int conStatus;
    SpriteRenderer spriteRenderer;
    private Rigidbody2D body;

    public float xForce;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        shouldJump = true;
    }

    private void Update()
    {
        var moving = (RightClicked - LeftClicked);
        spriteRenderer.flipX = !(moving > 0);

    }

    public void FixedUpdate()
    {
        var moving = (RightClicked - LeftClicked);

        if (moving != 0)
        {
            xForce = moving * Speed;
        }
        else
        {
            xForce = body.velocity.x;
        }

        var yForce = body.velocity.y;
        if (shouldJump)
        {
            yForce = JumpForce;
            shouldJump = false;
        }
        body.velocity = new Vector2(xForce, yForce);

        animator.SetFloat("Speed", Mathf.Abs(body.velocity.x));
    }


}
