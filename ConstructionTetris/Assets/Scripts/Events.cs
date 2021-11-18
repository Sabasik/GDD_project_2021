using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Events
{
    public static event Action<string> GameEndMessage;
    public static void SetMessage(string message) => GameEndMessage?.Invoke(message);


    static int[] LivesOptions = { 1, 3, 5 };
    static int[] TimeOptions = { 1, 3, 5 };
    static string[] DifficultyOptions = { "easy", "medium", "hard" };
    private static int livesOption = 1;
    private static int timeOption = 1;
    private static int diffOption = 1;

    public static int workerCount = 3;
    public static int lives = 3;
    public static float gameLength = 180f;
    public static string ChangeTime(bool increase)
    {
        if (increase)
        {
            if (timeOption >= 2) return "Length: " + TimeOptions[timeOption] + " min";
            timeOption += 1;
            gameLength += 120f;
        }
        else
        {
            if (timeOption <= 0) return "Length: " + TimeOptions[timeOption] + " min";
            timeOption -= 1;
            gameLength -= 120f;
        }
        return "Length: " + TimeOptions[timeOption] + " min";
    }

    public static string ChangeLives(bool increase)
    {
        if (increase)
        {
            if (livesOption >= 2) return "Lives: " + LivesOptions[livesOption];
            livesOption += 1;
            lives += 2;
        }
        else
        {
            if (livesOption <= 0) return "Lives: " + LivesOptions[livesOption];
            livesOption -= 1;
            lives -= 2;
        }
        return "Lives: " + LivesOptions[livesOption];
    }

    public static string ChangeDifficulty(bool increase)
    {
        if (increase)
        {
            if (diffOption >= 2) return "Difficulty: " + DifficultyOptions[diffOption];
            diffOption += 1;
            workerCount += 2;
        }
        else
        {
            if (diffOption <= 0) return "Difficulty: " + DifficultyOptions[diffOption];
            diffOption -= 1;
            workerCount -= 2;
        }
        return "Difficulty: " + DifficultyOptions[diffOption];
    }
}
