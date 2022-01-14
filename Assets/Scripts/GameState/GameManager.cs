using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameEvent showUI;
    public GameVariables game;
    public PlayerVariables player1, player2;

    public GameObject player1ActiveTab;
    public GameObject player2ActiveTab;

    private void OnEnable() 
    {
        player1ActiveTab.SetActive(false);
        player2ActiveTab.SetActive(false);
    }

    void Awake()
    {
        player1.Reset();
        player2.Reset();
        game.Reset();
    }

    void Start() {
        player1.playerTurn = true;
        player1ActiveTab.SetActive(true);
    }

    public void ChangePlayer(){
        game.playerTurn *= -1;
        game.allowDice = true;

        if(game.playerTurn == 1){

            player1.playerTurn = true;
            player1ActiveTab.SetActive(true);
            player2ActiveTab.SetActive(false);

        }else if(game.playerTurn == -1){

            player2.playerTurn = true;
            player2ActiveTab.SetActive(true);
            player1ActiveTab.SetActive(false);
        }

        if(player1.money <= 0){
            game.gameOver = true;
            showUI.message = "Player 1 lost";
            showUI.price = "Game Over";
            showUI.Raise();
        }

        if(player2.money <= 0){
            game.gameOver = true;
            showUI.message = "Player 2 lost";
            showUI.price = "Game Over";
            showUI.Raise();
        }
    }
}
