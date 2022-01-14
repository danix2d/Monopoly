using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopUI : MonoBehaviour
{
    public GameEvent showUI;

    public TextMeshProUGUI  message;
    public TextMeshProUGUI  price;

    public void Message()
    {
        message.text = showUI.message;
        price.text = showUI.price;
    }
}
