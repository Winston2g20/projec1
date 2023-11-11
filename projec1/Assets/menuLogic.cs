using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuLogic : MonoBehaviour
{
    public void nextScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void selectLevel1(){
        SceneManager.LoadScene("SampleScene");
    }
    public void selectLevel2(){
        SceneManager.LoadScene("Level 2");
    }
    public void selectLevel3(){
        SceneManager.LoadScene("Level 3");
    }
    public void selectLevel4(){
        SceneManager.LoadScene("Level 4");
    }
}
