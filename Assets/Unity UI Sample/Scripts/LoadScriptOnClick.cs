using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScriptOnClick : MonoBehaviour {

	public void LoadBySceneName(string name)
    {
        SceneManager.LoadScene(name);
    }

}
