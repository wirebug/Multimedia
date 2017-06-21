using System.IO;
using UnityEngine;

public class ScoreLogic : MonoBehaviour
{
    private static string lastScoreFileName = "lastScore.txt";
    private static string highScoreFileName = "highScore.txt";
    private static bool initialized = false;

    public static int Score { get; set; }
    public static int LastScore { get; private set; }
    public static int HighScore { get; private set; }

    public static void Init()
    {
        // Always reset current Score
        Score = 0;

        if (!initialized)
        {
            // Only reset LastScore and HighScore (and try to load them from file) on first Init
            LastScore = 0;
            HighScore = 0;
            DeSerializeScores();
            initialized = true;
        }
    }

    public static void Terminate()
    {
        if (initialized)
        {
            LastScore = Score;

            if (LastScore > HighScore)
            {
                HighScore = LastScore;
            }

            SerializeScores();
        }
    }

    private static void SerializeScores()
    {
        using (StreamWriter file =

            new StreamWriter(Path.Combine(Application.persistentDataPath, lastScoreFileName)))
        {
            file.WriteLine(LastScore);
        }

        using (StreamWriter file =
            new StreamWriter(Path.Combine(Application.persistentDataPath, highScoreFileName)))
        {
            file.WriteLine(HighScore);
        }
    }

    private static void DeSerializeScores()
    {
        if (File.Exists(Path.Combine(Application.persistentDataPath, lastScoreFileName)))
        {
            using (StreamReader file =
                new StreamReader(Path.Combine(Application.persistentDataPath, lastScoreFileName)))
            {
                string lastScoreString = file.ReadLine();
                int lastScoreValue = 0;

                if (System.Int32.TryParse(lastScoreString, out lastScoreValue))
                {
                    LastScore = lastScoreValue;
                }
            }
        }

        if (File.Exists(Path.Combine(Application.persistentDataPath, highScoreFileName)))
        {
            using (StreamReader file =
                new StreamReader(Path.Combine(Application.persistentDataPath, highScoreFileName)))
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
}
