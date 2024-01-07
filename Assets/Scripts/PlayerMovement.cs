using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer Sp;
    float dirX=0f;
    private BoxCollider2D coll;
    [SerializeField] public static float MoveSpeed = 7f;
    [SerializeField] private float JumForce=15f;
    [SerializeField] private LayerMask jumpableGround;
    private enum MovementState { idle,running,jum,fall}

    
    
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Sp = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2 (dirX* MoveSpeed , rb.velocity.y);
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            AudioManager.instance.Play("Jump");
            rb.velocity = new Vector2(rb.velocity.x, JumForce);
        }


        UpdateAnimation();
        
    }

    private void UpdateAnimation()
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.running;
            Sp.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            Sp.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }
        if(rb.velocity.y > .1f)
        {
            state= MovementState.jum;
        }else if(rb.velocity.y < -.1f)
        {
            state = MovementState.fall;
        }
        animator.SetInteger("state",(int)state);
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center,coll.bounds.size,0f,Vector2.down,.1f,jumpableGround);
    }
}
