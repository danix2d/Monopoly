using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Variables/PlayersSO", fileName = "PlayerSO")]
public class PlayerVariables : ScriptableObject
{
    public int playerID;
    public Sprite mark;
    public int waypointIndex;
    public int money;
    public bool move;
    public bool isMoving;
    public bool playerTurn;
    
    public void Reset()
    {
        money = 2500;
        isMoving = false;
        playerTurn = false;
        move = false;
        waypointIndex = 0;
    }
}
