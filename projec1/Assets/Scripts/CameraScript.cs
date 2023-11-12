using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CameraScript : MonoBehaviour
{

    Transform player;
    
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
        //if less than 10 dont move
        // otherwise follow the player
        if (playerx > -5 && playery > 0){
            this.transform.position = new Vector3(playerx + 5, playery, -10);
        }
        else if (playerx > -5) {
            this.transform.position = new Vector3(playerx + 5, 0, -10);
        }
        else if (playery > 0) {
            this.transform.position = new Vector3(0, playery, -10);
        }}
    }
}
