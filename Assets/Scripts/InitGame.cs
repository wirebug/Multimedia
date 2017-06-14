using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitGame : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
        ScoreLogic.Init();
	}

    private void OnGUI()
    {
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

    // Update is called once per frame
    void Update ()
    {
		
	}
}
