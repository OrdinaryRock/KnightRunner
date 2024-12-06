using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class GlobalVar
{
    public static int score;
    public static int highScore;
    public static bool dead;

    public static void SaveHighScore()
    {
        PlayerPrefs.SetInt("highscore", highScore);
    }

    public static void GetScore()
    {
        highScore = PlayerPrefs.GetInt("highscore");
    }
}
