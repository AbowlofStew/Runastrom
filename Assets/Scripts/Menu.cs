using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    public static bool isPaused;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //changes titelscene to main scene
    public void sceneChange() {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);

    }
    //changes title scene to credits scene
    public void sceneCredits()
    {
        SceneManager.LoadScene("Credits", LoadSceneMode.Single);

    }
    //pauses game
    public void pauseGame(){
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            isPaused = false;
        } else if(Time.timeScale == 1) {
            Time.timeScale = 0;
            isPaused = true;
        }
        

    }

    public void Continue()
    {
        SceneManager.LoadScene("titlescreen", LoadSceneMode.Single);
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Game Over", LoadSceneMode.Single);
    }
}
