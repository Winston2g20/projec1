using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    // public float jumpsleft; // if want to implement double jump
    // public bool dashleft; // if want to implement dashing
    // private int maxdownspeed = 5; // max downspeed for the ground pound
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        bool gravity = true // always down for now
    }
}
