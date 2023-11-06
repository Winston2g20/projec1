using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // find player x value
        float playerx = player.transform.position.x;
        //if less than 10 dont move
        // otherwise follow the player
        if (playerx > -5) {
            this.transform.position = new Vector3(playerx + 5, 0, -10);
        }
    }
}
