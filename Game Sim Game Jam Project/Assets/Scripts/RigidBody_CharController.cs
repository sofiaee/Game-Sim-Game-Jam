using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBody_CharController : MonoBehaviour
{
    public float moveSpeed = 2f;
    [Range (1, 10)]
    public float jumpVelocity;
    public LayerMask platformLayerMask;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    private Rigidbody2D playerRB;
    private bool jumpRequest;
    public bool grounded;
    private float groundedDistance = 0.05f;

    //Anim Stuff
    private SpriteRenderer mySpriteRenderer;
    private Animator myAnim;

    Vector2 playerSize;
    Vector2 boxSize;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerSize = GetComponent<CapsuleCollider2D>().size;
        boxSize = new Vector2(playerSize.x, groundedDistance);
        mySpriteRenderer = this.GetComponent<SpriteRenderer>();
        myAnim = this.GetComponent<Animator>();
    }

    private void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            jumpRequest = true;
        }
    }

    private void FixedUpdate()
    {
       //movement
        playerRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, playerRB.velocity.y);

       // Debug.Log(playerRB.velocity);
        if (jumpRequest)
        {
            playerRB.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
            jumpRequest = false;
            grounded = false;
        }
        else
        {
            Vector2 boxCenter = (Vector2)transform.position + Vector2.down * (playerSize.y + boxSize.y) * 0.5f;
            grounded = Physics2D.OverlapBox (boxCenter, boxSize, 0f, platformLayerMask) != null;
        }

        //added jump gravity
        if (playerRB.velocity.y < 0)
        {
            playerRB.gravityScale = fallMultiplier;
        }

        else if (playerRB.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            playerRB.gravityScale = lowJumpMultiplier;
        } 

        else
        {
            playerRB.gravityScale = 1f;
        }

        //Anim Stuff
        if (Input.GetAxisRaw("Horizontal") < -.01f)
        {
            mySpriteRenderer.flipX = true;
        }
        if (Input.GetAxisRaw("Horizontal") > .01f)
        {
            mySpriteRenderer.flipX = false;
        }
        if (grounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                myAnim.SetBool("isRunning", false);
                myAnim.SetBool("jumpNow", true);
            }
            else
            {
                if (Input.GetAxisRaw("Horizontal") > .01f  || Input.GetAxisRaw("Horizontal") < -.01f)
                {
                    myAnim.SetBool("jumpNow", false);
                    myAnim.SetBool("isRunning", true);
                }
                else
                {
                    myAnim.SetBool("jumpNow", false);
                    myAnim.SetBool("isRunning", false);
                }
            }
        }
    }

}
