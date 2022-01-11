using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Dice : MonoBehaviour
{
    public GameVariables gameState;
    public PlayerVariables player1 , player2;

    public GameObject diceFace;

    public Sprite[] dicePoints;

    private SpriteRenderer rend;

    private int randomDice = 0;

    void Start()
    {
        rend = diceFace.GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown() {
        if(gameState.allowDice && !gameState.gameOver)
        {
            StartCoroutine("RollDice");
        }
    }

    private IEnumerator RollDice(){

        gameState.allowDice = false;

        int num = Random.Range(15, 40);

        transform.DORotate(new Vector3(0,0,1800), num * 0.05f, RotateMode.FastBeyond360);

        for (int i = 0; i <= num; i++)
        {
            randomDice = Random.Range(0,6);
            rend.sprite = dicePoints[randomDice];
            yield return new WaitForSeconds(0.05f);
        }
        
        if(gameState.playerTurn == 1){
            player1.waypointIndex += randomDice + 1;
            player1.move = true;
            player1.isMoving = true;
        }

        if(gameState.playerTurn == -1){
            player2.waypointIndex += randomDice + 1;
            player2.move = true;
            player2.isMoving = true;
        }

    }
}
