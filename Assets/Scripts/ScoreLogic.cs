using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreLogic : MonoBehaviour {

    public static int Score = 0;
    private static float mTimeLeft = 60;
    public static float TimeLeft
    {
        get { return mTimeLeft; }
    }

    private void Start()
    {
        mTimeLeft = 60;
    }

    void OnGUI()
    {
        float x = Screen.width * 0.9f - Screen.height * 0.02f;
        float y = Screen.height * 0.05f;
        var textStyle = new GUIStyle();
        textStyle.fontSize = 50;
        textStyle.alignment = TextAnchor.UpperCenter;
        textStyle.fontStyle = FontStyle.Bold;
        textStyle.normal.textColor = Color.white;
        textStyle.alignment = TextAnchor.MiddleRight;
        GUI.Label(new Rect(x, y, Screen.width * 0.1f, Screen.height * 0.05f), Score.ToString(), textStyle);

        x = Screen.width * 0.9f - Screen.height * 0.02f;
        y = Screen.height * 0.9f;
        
        GUI.Label(new Rect(x, y, Screen.width * 0.1f, Screen.height * 0.05f), Mathf.Max(0, Mathf.Floor(mTimeLeft)).ToString(), textStyle);
    }

    // Update is called once per frame
    void Update () {
        mTimeLeft -= Time.deltaTime;
        if (mTimeLeft <= 0)
        {
            //TODO Finish
            SceneManager.LoadScene("StartMenu");
        }
	}
}
