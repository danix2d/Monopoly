using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public PlayerVariables currentPlayer;
    public PlayerVariables owner;

    public virtual void OnPoint (){}
}
