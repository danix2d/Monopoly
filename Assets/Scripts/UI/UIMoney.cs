using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMoney : MonoBehaviour
{
    public PlayerVariables player;
    public TMPro.TextMeshPro moneyTextUI;

    public void UpdateUI()
    {
        moneyTextUI.text = player.money.ToString() + "$";
    }
}
