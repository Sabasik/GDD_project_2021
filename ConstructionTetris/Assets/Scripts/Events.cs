using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Events
{
    public static event Action<string> GameEndMessage;
    public static void SetMessage(string message) => GameEndMessage?.Invoke(message);

    public static bool soundOn = true;

    public static int[] LivesOptions = { 1, 3, 5 };
    public static int[] TimeOptions = { 1, 3, 5 };
    public static string[] DifficultyOptions = { "easy", "medium", "hard" };
    public static int livesOption = 1;
    public static int timeOption = 1;
    public static int diffOption = 1;

    public static string[] ThemesOptions = { "original", "dark", "special" };
    //public static string theme = "original";

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

    public static void ChangeThemeOriginal(bool original)
    {
        if (original)
        {
            Spawner.theme = "original";
            Debug.Log("Theme was changed to original");
        }
    }

    public static void ChangeThemeDark(bool dark)
    {
        if (dark)
        {
            Spawner.theme = "dark";
            Debug.Log("Theme was changed to dark");
        }
    }
    public static void ChangeThemeSpecial(bool special)
    {
        if (special)
        {
            Spawner.theme = "special";
            Debug.Log("Theme was changed to special");
        }
    }
}
