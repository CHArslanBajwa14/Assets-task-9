using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    public float speed=0.10f;
    private Vector2 moveDirection;
    public float jumpStrength=1.0f;
    private new Collider2D[] overlaps =new Collider2D[4];
    private Collider2D collider;
    private bool grounded;
    private bool climbing;

    //private bool climbLadder = false;

   
    


    // Start is called before the first frame update
    void Start()
    {
        playerRb=GetComponent<Rigidbody2D>();
        //getting component for rigidbody
        //climbLadder=false;
        collider=GetComponent<Collider2D>();
        overlaps= new Collider2D[4];
    }

    // Update is called once per frame
    void Update()
    {
        CheckCollision();
        if(climbing)
        {
           moveDirection.y=Input.GetAxis("Vertical") * speed;
        }
        if(Input.GetButtonDown("Jump"))
        {
           moveDirection =Vector2.up*jumpStrength;
        }
        else{
            moveDirection += Physics2D.gravity * Time.deltaTime;
        }
        //making the player jump
       
        moveDirection.x=Input.GetAxis("Horizontal") * speed;
        playerRb.MovePosition(playerRb.position + moveDirection );
         moveDirection.y=Mathf.Max(moveDirection.y,0f);
         //to lower the strength by which gravity is pulling player down
        //will move player back and forth
        if(moveDirection.x > 0f)
        {
        transform.eulerAngles = Vector3.zero;
        }
        else if(moveDirection.x < 0f)
        {
        transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        // it will change the player facing direction

        //if(hit.layer == LayerMask.NameToLayer("Ladder"))
       // {
            //climbLadder=true;
           // moveDirection.y = Input.GetAxis("Vertical") * speed;
       // }

       

      
    }
    private void CheckCollision()
    {
       grounded = false;
        climbing = false;

        Vector3 size = collider.bounds.size;
        size.y += 0.1f;
        size.x /= 2f;

        int amount = Physics2D.OverlapBoxNonAlloc(transform.position, size, 0, overlaps);

        for (int i = 0; i < amount; i++)
        {
            GameObject hit = overlaps[i].gameObject;

           // if (hit.layer == LayerMask.NameToLayer("Ground"))
            //{
                // Only set as grounded if the platform is below the player
               // grounded = hit.transform.position.y < (transform.position.y - 0.5f);

                // Turn off collision on platforms the player is not grounded to
               // Physics2D.IgnoreCollision(overlaps[i], collider, !grounded);
           // }
             if (hit.layer == LayerMask.NameToLayer("Ladder"))
            {
                climbing = true;
            }
        }
    }
    }

