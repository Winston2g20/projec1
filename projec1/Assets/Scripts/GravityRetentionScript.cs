using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityRetentionScript : MonoBehaviour
{
    Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 globalGravity = Physics2D.gravity;
        if (globalGravity.y > 0)
        {
            rb.gravityScale = -Mathf.Abs(rb.gravityScale); // Ensure it's positive
        }
        else if (globalGravity.y < 0)
        {
            rb.gravityScale = Mathf.Abs(rb.gravityScale); // Ensure it's negative
        }
    }
}
