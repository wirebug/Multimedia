using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public string ScoreTextTag = "Score";
    public string TimeLeftTextTag = "TimeLeft";
    [HideInInspector]
    private Text scoreText;
    private Text timeLeftText;
    private float timeLeftTextMaxAlpha;
    private float timeLeftTextMinAlpha = 0.1f;
    private float timeLeftTextBlinkSpeed = 4.0f;

    void Start()
    {
        ScoreLogic.Init();
        GameObject scoreObj = GameObject.FindWithTag("Score");
        GameObject timeLeftObj = GameObject.FindWithTag("TimeLeft");

        if (null != scoreObj)
        {
            scoreText = scoreObj.GetComponent<Text>();
        }

        if (null != timeLeftObj)
        {
            timeLeftText = timeLeftObj.GetComponent<Text>();
            if (null != timeLeftText)
            {
                timeLeftTextMaxAlpha = timeLeftText.color.a;
            }
        }
    }

    void Update()
    {
        if (null != scoreText)
        {
            scoreText.text = "Score: " + ScoreLogic.Score;
        }

        if (null != timeLeftText)
        {
            int timeLeft = (int) TimeLogic.TimeLeft;

            if (timeLeft <= 10)
            {
                Color c = timeLeftText.color;
                c.a = (Mathf.Sin(Time.time * timeLeftTextBlinkSpeed) + 1.0f) * timeLeftTextMaxAlpha;
                if (c.a <= timeLeftTextMaxAlpha && c.a > timeLeftTextMinAlpha)
                {
                    timeLeftText.color = c;
                }
            }

            timeLeftText.text = "Time: " + TimeLogic.TimeLeft;
        }
    }

    void OnDestroy()
    {
        ScoreLogic.Terminate();
    }
}
