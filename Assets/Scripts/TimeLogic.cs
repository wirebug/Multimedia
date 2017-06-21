using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeLogic : MonoBehaviour
{
    [Tooltip("Round time in seconds")]
    public int RoundTime = 60;
    private static float timeLeft;

    public static float TimeLeft
    {
        get
        {
            return Mathf.Max(0, Mathf.Floor(timeLeft));
        }
    }

    void Start ()
    {
        timeLeft = RoundTime;
    }
	
	void Update ()
    {
        timeLeft -= Time.deltaTime;

        if (TimeLeft <= 0)
        {
            SceneManager.LoadScene("StartMenu");
        }
    }
}
