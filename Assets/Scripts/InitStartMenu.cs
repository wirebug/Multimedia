using UnityEngine;
using UnityEngine.UI;

public class InitStartMenu : MonoBehaviour
{
	void Start ()
    {
        ScoreLogic.Init();

        GameObject lastScoreObj = GameObject.FindWithTag("LastScore");
        GameObject highScoreObj = GameObject.FindWithTag("HighScore");

        if (null != lastScoreObj)
        {
            Text lastScoreText = lastScoreObj.GetComponent<Text>();
            if (null != lastScoreText)
            {
                lastScoreText.text = ScoreLogic.LastScore.ToString();
            }
        }

        if (null != highScoreObj)
        {
            Text highScoreText = highScoreObj.GetComponent<Text>();
            if (null != highScoreText)
            {
                highScoreText.text = ScoreLogic.HighScore.ToString();
            }
        }
    }
}
