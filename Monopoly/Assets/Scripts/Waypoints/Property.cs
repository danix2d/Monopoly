using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Property : Waypoint
{
    public int cost;
    public int pays;
    public GameEvent showUI;

    private SpriteRenderer rend;

    public override void OnPoint ()
    {
        base.OnPoint();

        if(owner == null)
        {
            if(currentPlayer.money > cost)
            {
                owner = currentPlayer;
                currentPlayer.money -= cost;

                GameObject playerMark = new GameObject();
                playerMark.name = "Player " + currentPlayer.playerID + " Mark";
                playerMark.transform.position = this.transform.position;
                playerMark.transform.rotation = this.transform.rotation;
                playerMark.AddComponent<SpriteRenderer>();
                rend = playerMark.GetComponent<SpriteRenderer>();
                rend.sprite = currentPlayer.mark;

                Debug.Log("Player " + owner.playerID + " Bought this property");
                showUI.message = "You Bought this property";
                showUI.price = "For " + cost + "$";
                showUI.Raise();
            }else{
                showUI.message = "You can't buy this property";
                showUI.price = "$$$";
                showUI.Raise();
                return;
            }
        }else if(owner != currentPlayer){
            currentPlayer.money -= pays;
            owner.money += pays;
            Debug.Log("Player " + currentPlayer.playerID + "paid 200$ to Player " + owner.playerID);
            showUI.message = "You landed on Player " + owner.playerID + " property";
            showUI.price = "Lose " + pays + "$";;
            showUI.Raise();
        }
        
    }
}
