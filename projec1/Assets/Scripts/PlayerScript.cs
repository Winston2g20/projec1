using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D collider;
    SpriteRenderer sr;
    public float speed;
    public float jumpForce;
    private float movementX;
    private float movementY;
    // public float jumpsleft; // if want to implement double jump
    private int dashleft; // if want to implement dashing
    private float dashmultiplier = 1;
    private float theforce;
    private bool gravflipped = false;
    public AudioSource jumpSoundEffect;
    public AudioSource deathSoundEffect;
    public AudioSource coinCollectSoundEffect;

    [HideInInspector]
    public bool dead = false;
    // private int maxdownspeed = 5; // max downspeed for the ground pound
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        dashleft = 1;
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

    theforce = movementX * speed * 10 * dashmultiplier;

    rb.AddForce(horizontalmovement * speed * 10 * dashmultiplier);

    if (movementX < 0){
        sr.flipX = true;
    }
    if (movementX > 0){
        sr.flipX = false;
    }

    if (movementX == 0 && movementY == 0 && IsGrounded()){
        rb.velocity = new Vector3(0,0);
    }

    // lower dash multiplier by 0.02 every frame until its 1
    if (dashmultiplier > 1f){
        dashmultiplier -= 0.02f;
    }

    }

    void Update(){
        if (IsGrounded()){
            dashleft = 1;
        }
         if (Input.GetKeyDown(KeyCode.W)) { // Now checking for the "W" key
        Jump();
    }
        if (Input.GetKeyDown(KeyCode.S)) { // Now checking for the "S" key
        RevJump();
    }
        if (Input.GetKeyDown(KeyCode.LeftShift)) { // Now checking for the "Left shift" key
        Dash();
        Debug.Log("Dash Triggered");
        Debug.Log(theforce);
    }
        if (Input.GetKeyDown(KeyCode.Space)){
            FlipGravity();
        }
    }



    bool IsGrounded() {
    LayerMask layerMask = LayerMask.GetMask("Ground"); 
    Vector2 raycastOrigin = new Vector2(transform.position.x, transform.position.y - 0.3f);
    RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, Vector2.down, 0.5f, layerMask); 
    return hit.collider != null;}

    bool IsRevGrounded() {
    LayerMask layerMask = LayerMask.GetMask("Ground"); 
    Vector2 raycastOrigin = new Vector2(transform.position.x, transform.position.y + 0.3f);
    RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, Vector2.up, 0.5f, layerMask); 
    return hit.collider != null;}

    void Jump(){
    if (IsGrounded()) {
        jumpSoundEffect.Play();
        if(Physics2D.gravity.y < 0){
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);}
        else{
             GetComponent<Rigidbody2D>().AddForce(Vector2.down * jumpForce, ForceMode2D.Impulse);}
        }
    }
    void RevJump(){
    if (IsRevGrounded()) {
        GetComponent<Rigidbody2D>().AddForce(Vector2.down * jumpForce, ForceMode2D.Impulse);
    }
    }
    
    
    void Dash(){
        if(dashleft > 0){
            Debug.Log("Dash executed");
            //set horizontal speed to 1.5x the speed variable
            dashmultiplier = 2f;
            dashleft -= 1; 
            //every frame put it down by 0.01x 
            //until its back at normal speed
        }
    }

    void FlipGravity(){
        gravflipped = !gravflipped;
        sr.flipY = gravflipped;
        GameControllerScript.Instance.FlipGravity();
        
        }
    

    void OnCollisionEnter2D(Collision2D collision)
    {
        int layer = collision.gameObject.layer;
        string layerName = LayerMask.LayerToName(layer);
        
        if (collision.gameObject.layer == LayerMask.NameToLayer("Hazard"))
        {
            Die();
        }

      
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Coin"))
        {
            CollectCoin();
            coinCollectSoundEffect.Play();
            Destroy(other.gameObject);
        }


        if (other.gameObject.layer == LayerMask.NameToLayer("Finish"))
        {
            Finish();
        }
    }

    void Die()
    {
       GameControllerScript.Instance.Die();
       gameObject.SetActive(false);
    }

    void CollectCoin(){
        GameControllerScript.Instance.CollectCoin();
    }

    void Finish(){
        GameControllerScript.Instance.Finish();
        gameObject.SetActive(false);
    }
}


