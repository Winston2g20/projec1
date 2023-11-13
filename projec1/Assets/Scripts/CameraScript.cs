using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CameraScript : MonoBehaviour
{

    Transform player;
    public float margin = 4;
    public float marginy = 2;
    public float smoothSpeed = 5f;
    public float yoffset = 0;
    
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // find player x value
        if (player){
        float playerx = player.transform.position.x;
        float playery = player.transform.position.y;
        float camerax = transform.position.x;
        float cameray = transform.position.y;
        
        //if less than 10 dont move
        // otherwise follow the player
        Vector3 targetPosition = new Vector3(playerx + margin, playery + yoffset, -10);

        if (camerax -  playerx < margin){
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }
        if (camerax - playerx > -margin) {
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }
        if (cameray - playery < margin) {
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);

        }
        if (cameray - playery > -margin) {
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);

        }

        
       
        
        }
    }

    public void FlipGravity(){

            yoffset = -yoffset;
            marginy = -marginy;}
}
