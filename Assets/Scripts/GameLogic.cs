using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public string ScoreTextTag = "Score";
    public string TimeLeftTextTag = "TimeLeft";
    [HideInInspector]
    private Text scoreText;
    private Text timeLeftText;

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
            timeLeftText.text = "Time: " + TimeLogic.TimeLeft;
        }
    }

    void OnDestroy()
    {
        ScoreLogic.Terminate();
    }
}
