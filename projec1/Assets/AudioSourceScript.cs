using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceScript : MonoBehaviour
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
        if (player){
        float playerx = player.transform.position.x;
        float playery = player.transform.position.y;
        this.transform.position = new Vector3(playerx, playery, -10);
        }

    }
}
