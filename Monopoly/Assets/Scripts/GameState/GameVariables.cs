using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Variables/GameSO", fileName = "GameVariables")]
public class GameVariables : ScriptableObject
{
    public bool gameOver;
    public bool playerIsMoving;
    public int playerTurn;
    public bool allowDice;

    public void Reset()
    {
        allowDice = true;
        gameOver = false;
        playerIsMoving = false;
        playerTurn = 1;
    }
}
