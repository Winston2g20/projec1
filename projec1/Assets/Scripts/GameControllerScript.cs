using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameControllerScript : MonoBehaviour
{
    GameObject player;
    GameObject deathScreen;
    GameObject victoryScreen;

    public AudioSource deathSoundEffect;
    public AudioSource buttonClickSFX;
    public GameObject camera;
    public int totalCoinCounter = 0;
    
    [HideInInspector] public CameraScript cameraScript;
    [HideInInspector] public TextMeshProUGUI coinCount;
    [HideInInspector] public TextMeshProUGUI totalCoinCount;
    [HideInInspector] private int coinCounter = 0;


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
    Physics2D.gravity = new Vector2(0, -9.8f);
    player = GameObject.Find("Player");
    coinCount = GameObject.Find("Coin count").GetComponent<TextMeshProUGUI>();
    totalCoinCount = GameObject.Find("totalCoinCount").GetComponent<TextMeshProUGUI>();
    deathScreen = GameObject.Find("DeathScreen");
    deathScreen.SetActive(false);
    victoryScreen = GameObject.Find("VictoryScreen");
    victoryScreen.SetActive(false);
    cameraScript = camera.GetComponent<CameraScript>();

    }

    // Update is called once per frame
    
    void Update()
    {
      coinCount.text = coinCounter.ToString();
      totalCoinCount.text = "/ " + totalCoinCounter.ToString(); 

    }

    public void Die(){
        deathSoundEffect.Play();
        deathScreen.SetActive(true);
    }

    public void NextScene(){
        
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void ReloadScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    public void BackToMenu(){
        SceneManager.LoadScene(0);
    }

    public void CollectCoin(){
        coinCounter++;
        Debug.Log("COIN COLLECTED");
    }

    public void Finish(){
        victoryScreen.SetActive(true);
    }

    public void playButtonSFX(){
        buttonClickSFX.Play();
    }

    public void FlipGravity(){
        Physics2D.gravity = -Physics2D.gravity;
        cameraScript.FlipGravity();
       
    }

    

    
}
