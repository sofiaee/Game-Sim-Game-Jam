using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    Rigidbody2D myRigidBody;
    public Transform redPoint;
    public Transform bluePoint;

    private bool touchedBlue;
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        touchedBlue = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
        if (myRigidBody.transform.position == bluePoint.transform.position)
        {
            touchedBlue = true;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
        if (myRigidBody.transform.position == redPoint.transform.position)
        {
            touchedBlue = false;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }


        
    }

    private void Move()
    {
        // myRigidBody.velocity = new Vector2(moveSpeed, 0f);
        float step = moveSpeed * Time.deltaTime;
        if (touchedBlue)
        {
            myRigidBody.transform.position = Vector2.MoveTowards(myRigidBody.transform.position, redPoint.transform.position, step);
            
        }
        if (touchedBlue == false)
        {
            myRigidBody.transform.position = Vector2.MoveTowards(myRigidBody.transform.position, bluePoint.transform.position, step);
            
        }
        
    }

   /* private void OnTriggerExit2D(Collider2D collision)
    {
        moveSpeed = -moveSpeed;
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }*/
    
}