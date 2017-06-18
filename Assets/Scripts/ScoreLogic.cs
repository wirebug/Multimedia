using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreLogic : MonoBehaviour {

    public static int HighScore = 0;
    public static int LastScore = 0;
    private static float timeLeft = 60;
    public static float TimeLeft
    {
        get { return timeLeft; }
    }
    private static string lastScoreFileName =  "lastScore.txt";
    private static string highScoreFileName = "highScore.txt";

    public static void Init()
    {
        DeSerializeScores();
    }

    void Start()
    {
        LastScore = 0;
        timeLeft = 60;
    }

    void OnGUI()
    {
        float x = Screen.width * 0.9f - Screen.height * 0.02f;
        float y = Screen.height * 0.05f;
        var textStyle = new GUIStyle()
        {
            fontSize = 50,
            alignment = TextAnchor.UpperCenter,
            fontStyle = FontStyle.Bold
        };
        textStyle.normal.textColor = Color.white;
        textStyle.alignment = TextAnchor.MiddleRight;
        GUI.Label(new Rect(x, y, Screen.width * 0.1f, Screen.height * 0.05f), LastScore.ToString(), textStyle);

        x = Screen.width * 0.9f - Screen.height * 0.02f;
        y = Screen.height * 0.9f;
        
        GUI.Label(new Rect(x, y, Screen.width * 0.1f, Screen.height * 0.05f), Mathf.Max(0, Mathf.Floor(timeLeft)).ToString(), textStyle);
    }

    // Update is called once per frame
    void Update () {
        timeLeft -= Time.deltaTime;

        LastScore++; // TODO: TEST ONLY, REMOVE!
        
        if (timeLeft <= 0)
        {
            //TODO Finish
            SceneManager.LoadScene("StartMenu");
        }
	}

    void OnDestroy()
    {
        if (LastScore > HighScore)
        {
            HighScore = LastScore;
        }

        SerializeScores();
    }

    private static void SerializeScores()
    {
        using (System.IO.StreamWriter file =

            new System.IO.StreamWriter(Path.Combine(Application.persistentDataPath, lastScoreFileName)))
        {
            file.WriteLine(LastScore);
        }

        using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(Path.Combine(Application.persistentDataPath, highScoreFileName)))
        {
            file.WriteLine(HighScore);
        }
    }

    private static void DeSerializeScores()
    {
        if (IsFileValid(Path.Combine(Application.persistentDataPath, lastScoreFileName)))
        {
            using (System.IO.StreamReader file =
                new System.IO.StreamReader(Path.Combine(Application.persistentDataPath, lastScoreFileName)))
            {
                string lastScoreString = file.ReadLine();
                int lastScoreValue = 0;

                if (System.Int32.TryParse(lastScoreString, out lastScoreValue))
                {
                    LastScore = lastScoreValue;
                }
            }
        }

        if (IsFileValid(Path.Combine(Application.persistentDataPath, highScoreFileName)))
        {
            using (System.IO.StreamReader file =
                new System.IO.StreamReader(Path.Combine(Application.persistentDataPath, highScoreFileName)))
            {
                string highScoreString = file.ReadLine();
                int highScoreValue = 0;

                if (System.Int32.TryParse(highScoreString, out highScoreValue))
                {
                    HighScore = highScoreValue;
                }
            }
        }
    }

    private static bool IsFileValid(string filePath)
    {
        if (File.Exists(filePath))
        {
            return false;
        }

        return true;
    }
}
