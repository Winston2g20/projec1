using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameControllerScript : MonoBehaviour
{
    GameObject player;
    GameObject deathScreen;
    // Start is called before the first frame update
    void Start()
    {
    player = GameObject.Find("Player");
    deathScreen = GameObject.Find("DeathScreen");
    deathScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
     if(player.GetComponent<PlayerScript>().dead == true){
        deathScreen.SetActive(true);
     }   
    }

    public void ReloadScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu(){
        SceneManager.LoadScene(0);
    }
}
