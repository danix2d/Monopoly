using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{

    public GameEvent changePlayer;

    public PlayerVariables player;


    public Waypoint[] points;


    private int pointIndex = 0;
    private Transform objTransform;
    private Vector3 dest;

    void Start()
    {
        objTransform = GetComponent<Transform>();
    }


    void Update()
    {
        if(player.move){
            Move();
            player.move = false;
        }
    }

    private void Move()
    {
        if(pointIndex >= player.waypointIndex){
            EndMove();
            return;
        }

        if (points.Length > 0){
            GotoNextPoint();
        }
        Vector3 rand = new Vector3(Random.Range(-0.5f,0.5f),Random.Range(-0.5f,0.5f),0);
        objTransform.DOMove(dest + rand, 0.3f, false).OnComplete(Move).SetEase(Ease.InOutSine);
    }

    public void GotoNextPoint()
    {
        pointIndex += 1;

        if (pointIndex == points.Length)
        {
            player.waypointIndex = player.waypointIndex % points.Length;
            pointIndex = 0;
        }

        dest = points[pointIndex].transform.position;
        dest.z = 0;
    }

    public void EndMove(){
        objTransform.DOShakeScale(0.25f);
        player.isMoving = false;
        player.playerTurn = false;

        points[player.waypointIndex].currentPlayer = player;
        points[player.waypointIndex].OnPoint();

        changePlayer.Raise();
    }

}
