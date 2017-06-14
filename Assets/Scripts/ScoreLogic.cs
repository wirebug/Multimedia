using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreLogic : MonoBehaviour {

    public static int Score = 0;

    void OnGUI()
    {
        float x = Screen.width * 0.9f - Screen.height * 0.02f;
        float y = Screen.height * 0.05f;
        var scoreStyle = new GUIStyle();
        scoreStyle.fontSize = 50;
        scoreStyle.alignment = TextAnchor.UpperCenter;
        scoreStyle.fontStyle = FontStyle.Bold;
        scoreStyle.normal.textColor = Color.white;
        scoreStyle.alignment = TextAnchor.MiddleRight;

        GUI.Label(new Rect(x, y, Screen.width * 0.1f, Screen.height * 0.05f), Score.ToString(), scoreStyle);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
