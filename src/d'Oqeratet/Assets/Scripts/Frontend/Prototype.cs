using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Prototype : MonoBehaviour
{
    private int[] php = {0, 0, 0, 0};
    private int[] pstamina = {20, 20, 20, 20};
    private int thp = 12;
    private int tstamina = 6;

    private TurnManager tm;

    private int round;
    private int turn;

    public GameObject gamehand;
    public TMP_Text player1;
    public TMP_Text player2;
    public TMP_Text player3;
    public TMP_Text player4;
    public TMP_Text tenta;

    void Start() {
        tm = GameObject.Find("Stage Hand").GetComponent<TurnManager>();
    }

    void Update()
    {
        round = tm.round;
        turn = tm.turn;
        turn++;
        //thp = gamehand.GetComponent<GameObject>;
        //tstamina = gamehand.stamina;

        player1.text = "Player 1 \nHP: " + php[0] + "\nStamina: " + pstamina[0];
        player2.text = "Player 2 \nHP: " + php[1] + "\nStamina: " + pstamina[1];
        player3.text = "Player 3 \nHP: " + php[2] + "\nStamina: " + pstamina[2];
        player4.text = "Player 4 \nHP: " + php[3] + "\nStamina: " + pstamina[3];
        tenta.text = "-Tenta-" + "\nHP: " + thp + "\nStamina: " + tstamina + "\nRound: " + round + "\nTurn: " + turn;
    }
}


