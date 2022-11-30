using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : MonoBehaviour
{
     private float Vertical;
    private float verticalSpeed= 8.0f;
    private  bool isladder;
    private bool isclimbing;
   public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vertical = Input.GetAxis("Vertical");

        if(isladder && Vertical > 0f)
        {
            isclimbing = true;
        }
    }

    private void FixedUpdate()
    {
        if (isclimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, Vertical * verticalSpeed);
        }
        else
        {
            rb.gravityScale = 1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            isladder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            isladder = false;
            isclimbing = false;
        }
    }
}