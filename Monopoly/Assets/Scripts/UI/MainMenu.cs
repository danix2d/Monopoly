using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameVariables gameVariables;
    public PlayerVariables player1, player2;

    public void Reset(){
        gameVariables.Reset();
        player1.Reset();
        player2.Reset();
    }
}
