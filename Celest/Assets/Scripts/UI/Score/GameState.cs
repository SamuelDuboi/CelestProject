using UnityEngine;
[System.Serializable]
public static class GameState 
{
    public static int score =0;
    public static int initCheckPoint;
    public static Vector2 initCheckPointPos;
    public static Vector2 currentCheckPointPos;
    public static int currentCheckPoint;
    public static bool isPaused;

    public static int currentLife = 3;

}
