using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBody_CharController : MonoBehaviour
{
    public float moveSpeed = 2f;
    [Range (1, 10)]
    public float jumpVelocity;
    public float gravityDirection;
    public LayerMask platformLayerMask;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    [SerializeField] Vector2 deathFly = new Vector2(2f, 2f);

    private Rigidbody2D playerRB;
    private bool jumpRequest;
    public bool grounded;
    private float groundedDistance = 0.05f;
    public bool isAlive = true;

    //Anim Stuff
    private SpriteRenderer mySpriteRenderer;
    private Animator myAnim;

    BoxCollider2D myBodyCollider;

    Vector2 playerSize;
    Vector2 boxSize;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerSize = GetComponent<CapsuleCollider2D>().size;
        myBodyCollider = GetComponent<BoxCollider2D>();
        boxSize = new Vector2(playerSize.x, groundedDistance);
        mySpriteRenderer = this.GetComponent<SpriteRenderer>();
        myAnim = this.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            jumpRequest = true;
        }
        //Gravity Switch
        GravitySwitch();
    }


    private void FixedUpdate()
    {
        if(!isAlive) { return; }

        CharAnimate();
        CharMovement();
        // Debug.Log(playerRB.velocity);
        CharJumpRequest();
        CharJumpGravity();
        Die();
    }

    //movement
    private void CharMovement()
    {
        if (gravityDirection == 0 || gravityDirection == 2)
        {
            playerRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, playerRB.velocity.y);
        }
        else
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
        }
    }

    private void CharJumpRequest()
    {
        if (jumpRequest)
        {

            if (gravityDirection == 1) //Leftward
            {
                playerRB.AddForce(Vector2.right * jumpVelocity, ForceMode2D.Impulse);
            }
            else
            {
                if (gravityDirection == 2) //Upward
                {
                    playerRB.AddForce(Vector2.down * jumpVelocity, ForceMode2D.Impulse);
                }
                else
                {
                    if (gravityDirection == 3) //Rightward
                    {
                        playerRB.AddForce(Vector2.left * jumpVelocity, ForceMode2D.Impulse);
                    }
                    else //Downward, original a.k.a. gravityDirection == 0
                    {
                        playerRB.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
                    }
                }
            }
            jumpRequest = false;
            grounded = false;
        }
        else
        {
            CharGrounded();
        }
    }

    private void CharGrounded()
    {
        if (gravityDirection == 0) //Downward, original
        {
            Vector2 boxCenter = (Vector2)transform.position + Vector2.down * (playerSize.y + boxSize.y) * 0.5f;
            grounded = Physics2D.OverlapBox(boxCenter, boxSize, 0f, platformLayerMask) != null;
        }
        if (gravityDirection == 1) //Leftward
        {
            Vector2 boxCenter = (Vector2)transform.position + Vector2.left * (playerSize.x + boxSize.x) * 0.5f;
            grounded = Physics2D.OverlapBox(boxCenter, boxSize, 0f, platformLayerMask) != null;
        }
        if (gravityDirection == 2) //Upward
        {
            Vector2 boxCenter = (Vector2)transform.position + Vector2.up * (playerSize.y + boxSize.y) * 0.5f;
            grounded = Physics2D.OverlapBox(boxCenter, boxSize, 0f, platformLayerMask) != null;
        }
        if (gravityDirection == 3) //Rightward
        {
            Vector2 boxCenter = (Vector2)transform.position + Vector2.right * (playerSize.x + boxSize.x) * 0.5f;
            grounded = Physics2D.OverlapBox(boxCenter, boxSize, 0f, platformLayerMask) != null;
        }
    }

    //added jump gravity
    private void CharJumpGravity()
    {
        if (gravityDirection == 0) //Downward fall
        {
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
        }
        else
        {
            if (gravityDirection == 1) //Leftward fall
            {
                if (playerRB.velocity.x < 0)
                {
                    playerRB.gravityScale = fallMultiplier;
                }
                else if (playerRB.velocity.x > 0 && !Input.GetKey(KeyCode.Space))
                {
                    playerRB.gravityScale = lowJumpMultiplier;
                }
                else
                {
                    playerRB.gravityScale = 1f;
                }
            }
            else
            {
                if (gravityDirection == 2) //Upward fall
                {
                    if (playerRB.velocity.y > 0)
                    {
                        playerRB.gravityScale = fallMultiplier;
                    }
                    else if (playerRB.velocity.y < 0 && !Input.GetKey(KeyCode.Space))
                    {
                        playerRB.gravityScale = lowJumpMultiplier;
                    }
                    else
                    {
                        playerRB.gravityScale = 1f;
                    }
                }
                else //Rightward fall
                {
                    if (playerRB.velocity.x > 0)
                    {
                        playerRB.gravityScale = fallMultiplier;
                    }
                    else if (playerRB.velocity.x < 0 && !Input.GetKey(KeyCode.Space))
                    {
                        playerRB.gravityScale = lowJumpMultiplier;
                    }
                    else
                    {
                        playerRB.gravityScale = 1f;
                    }
                }
            }
        }
    }

    //Anim Stuff
    private void CharAnimate()
    {
        if ((Input.GetAxisRaw("Horizontal") < -.01f && (gravityDirection == 0 || gravityDirection == 2)) || (Input.GetAxisRaw("Vertical") > .01f && (gravityDirection == 1 || gravityDirection == 3)))
        {
            mySpriteRenderer.flipX = true;
        }
        if ((Input.GetAxisRaw("Horizontal") > .01f && (gravityDirection == 0 || gravityDirection == 2)) || (Input.GetAxisRaw("Vertical") < -.01f) && (gravityDirection == 1 || gravityDirection == 3))
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
                if (Input.GetAxisRaw("Horizontal") > .01f  || Input.GetAxisRaw("Horizontal") < -.01f || Input.GetAxisRaw("Vertical") > .01f || Input.GetAxisRaw("Vertical") < -.01f)
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

    private void GravitySwitch()
    {
        if (Input.GetKey(KeyCode.Alpha1)) //Downward
        {
            gravityDirection = 0;
            Physics2D.gravity = new Vector2(0, -9.81f);
        }
        if (Input.GetKey(KeyCode.Alpha2)) //Leftward
        {
            gravityDirection = 1;
            Physics2D.gravity = new Vector2(-9.81f, 0);
        }
        if (Input.GetKey(KeyCode.Alpha3)) //Upward
        {
            gravityDirection = 2;
            Physics2D.gravity = new Vector2(0, 9.81f);
        }
        if (Input.GetKey(KeyCode.Alpha4)) //Rightward
        {
            gravityDirection = 3;
            Physics2D.gravity = new Vector2(9.81f, 0);
        }
        Rotation();//Animation matches gravitational orientation
    }

    private void Rotation()
    {
        if (gravityDirection == 1) //Leftward
        {
            transform.eulerAngles = new Vector3(0, 0, 270f);
        }
        else
        {
            if (gravityDirection == 2) //Upward
            {
                transform.eulerAngles = new Vector3(180f, 0, 0);
            }
            else
            {
                if (gravityDirection == 3) //Rightward
                {
                    transform.eulerAngles = new Vector3(180f, 0, 90f);
                }
                else //Downward
                {
                    transform.eulerAngles = Vector3.zero;
                }
            }
        }
        
    }
    
    private void Die()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Hazard")))
        {
            isAlive = false;
            myAnim.SetTrigger("Die");
            GetComponent<Rigidbody2D>().velocity = deathFly;
        }
    }

    private void OnTriggerEnter2D(Collider2D Collider)
    {
        Debug.Log("Trigger!");
 /*       if (Collider.gravityFieldDirection() == 0)
        {

        }*/
    }
}
