using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameControllerScript : MonoBehaviour
{
    GameObject player;
    GameObject deathScreen;
    GameObject victoryScreen;
    public AudioSource deathSoundEffect;
    public AudioSource buttonClickSFX;


        // Singleton pattern
    private static GameControllerScript _instance;

    public static GameControllerScript Instance
    {
        get
        {
            if (_instance == null)
            {
                // If the instance is null, find or create a GameControllerScript object
                _instance = FindObjectOfType<GameControllerScript>();

                if (_instance == null)
                {
                    // If GameControllerScript doesn't exist in the scene, create an empty GameObject and add GameControllerScript component
                    GameObject singletonObject = new GameObject("GameControllerScript");
                    _instance = singletonObject.AddComponent<GameControllerScript>();
                }
            }

            return _instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    player = GameObject.Find("Player");
    deathScreen = GameObject.Find("DeathScreen");
    deathScreen.SetActive(false);
    victoryScreen = GameObject.Find("VictoryScreen");
    victoryScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void Die(){
        deathSoundEffect.Play();
        deathScreen.SetActive(true);
    }

    public void ReloadScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu(){
        SceneManager.LoadScene(0);
    }

    public void CollectCoin(){
        Debug.Log("COIN COLLECTED");
    }

    public void Finish(){
        deathScreen.SetActive(true);
    }

    public void playButtonSFX(){
        buttonClickSFX.Play();
    }
}
