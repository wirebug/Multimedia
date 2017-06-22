using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;

public class TimeLogic : MonoBehaviour
{
    [Tooltip("Round time in seconds")]
    public int RoundTime = 60;
    [HideInInspector]
    private static float timeLeft;

    public static float TimeLeft
    {
        get
        {
            return Mathf.Max(0, Mathf.Floor(timeLeft));
        }
    }

    void Start()
    {
        timeLeft = RoundTime;
    }

    void Update()
    {
        if (IsRunning())
        {
            timeLeft -= Time.deltaTime;

            if (TimeLeft <= 0)
            {
                SceneManager.LoadScene("StartMenu");
            }
        }

    }

    public static bool IsRunning()
    {
        // only run while we have an image tracked
        return TrackerManager.Instance.GetStateManager().GetActiveTrackableBehaviours().GetEnumerator().MoveNext();
    }
}
