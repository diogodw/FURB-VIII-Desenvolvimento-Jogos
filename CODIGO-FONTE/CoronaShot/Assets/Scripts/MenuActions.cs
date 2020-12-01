using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuActions : MonoBehaviour
{

    public void Quit() {
        Application.Quit();
    }

    public void Start() {

        // INITIALIZE ALL STATS
        Manager.Instance.Start();
        PlayerPrefs.SetInt("Health", 5);
        
        //START THE GAME
        Time.timeScale = 1; 

        //LOAD GAME SCENE
        SceneManager.LoadScene(1);

    }

    public void Resume() {
        Manager.Instance.Resume();
    }

}
