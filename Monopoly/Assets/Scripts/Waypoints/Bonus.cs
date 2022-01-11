using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : Waypoint
{
    [System.Serializable]
    public class DropCurrency
    {
        public int money;
        public int rarity;
    }


    public GameEvent showUI;

    public bool StartPosition = false;

    public List<DropCurrency> loot = new List<DropCurrency>();

    public override void OnPoint ()
    {
        base.OnPoint();

        if(StartPosition)
        {
            currentPlayer.money += 150;
            Debug.Log("You win 150$ " + currentPlayer.playerID);
            showUI.message = "You landed on Start";
            showUI.price = "Win " + 150 + "$";
            showUI.Raise();
        }else{
            CalculateWeight();
        }
    }

    void CalculateWeight()
    {
        int lootWeight = 0;
        
        for (int i = 0; i < loot.Count; i++)
        {
            lootWeight += loot[i].rarity;
        }

        int randValue = Random.Range(0, lootWeight);
        int top = 0;
        
        for (int j = 0; j < loot.Count; j++)
        {
            top += loot[j].rarity;
            if (randValue < top){
                currentPlayer.money += loot[j].money;
                Debug.Log("You win  " + loot[j].money);
                showUI.message = "You landed on a bonus";
                showUI.price = "Win " + loot[j].money + "$";
                showUI.Raise();
                break;
            }
        }

    }


}
