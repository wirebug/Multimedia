using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour {
	
	void Update ()
    {
        if (Application.platform == RuntimePlatform.Android && Input.GetKey(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("default"))
            {
                SceneManager.LoadScene("StartMenu");
            }
            else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("StartMenu"))
            {
                Application.Quit();
            }

            
        }
    }
}
