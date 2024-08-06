using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerData
{

    static string playerName;
    static int playerScore;
    
    public static void SetPlayerName(string newPlayerName)
    {
        playerName = newPlayerName;
    }

    public static string GetPlayerName() => playerName;


}
