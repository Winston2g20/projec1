using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D collider;
    public float speed;
    public float jumpForce;
    private float movementX;
    private float movementY;
    // public float jumpsleft; // if want to implement double jump
    // public bool dashleft; // if want to implement dashing
    // private int maxdownspeed = 5; // max downspeed for the ground pound
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
    }

    void OnMove(InputValue movementValue){
    Vector2 movementVector = movementValue.Get<Vector2>();
    movementX = movementVector.x;
    movementY = movementVector.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    Vector3 horizontalmovement = new Vector3(movementX,0);
    Vector4 verticalmovement = new Vector4(0,movementY);

    rb.AddForce(horizontalmovement * speed * 10);

    
    }

    void Update(){
         if (Input.GetKeyDown(KeyCode.W)) { // Now checking for the "W" key
        Jump();
    }

    }



    bool IsGrounded() {
    LayerMask layerMask = LayerMask.GetMask("Ground"); 
    Vector2 raycastOrigin = new Vector2(transform.position.x, transform.position.y - 0.3f);
    RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, Vector2.down, 0.3f, layerMask); 
    return hit.collider != null;}

    void Jump(){
    if (IsGrounded()) {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
    }

  
}


