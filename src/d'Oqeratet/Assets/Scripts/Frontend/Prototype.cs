using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Prototype : MonoBehaviour
{
    private int thp;
    private int tstamina;

    public TurnManager tm;
    private Card card;

    private int round;
    private int turn;

    public TMP_Text player1;
    public TMP_Text player2;
    public TMP_Text player3;
    public TMP_Text player4;
    public TMP_Text tenta;

    private int[] php;
    private int[] pstamina;

    void Start() {
        card = tm.card;
    }

    void Update()
    {
        php = new int[] { tm.player1.hp, tm.player2.hp, tm.player3.hp, tm.player4.hp };
        pstamina = new int[] { tm.player1.stamina, tm.player2.stamina, tm.player3.stamina, tm.player4.stamina };
        round = tm.round;
        turn = tm.turn;
        turn++;

        thp = card.hpGain;
        tstamina = card.staminaCost;
        //thp = gamehand.GetComponent<GameObject>;
        //tstamina = gamehand.stamina;

        player1.text = "Player 1 \nHP: " + php[0] + "\nStamina: " + pstamina[0];
        player2.text = "Player 2 \nHP: " + php[1] + "\nStamina: " + pstamina[1];
        player3.text = "Player 3 \nHP: " + php[2] + "\nStamina: " + pstamina[2];
        player4.text = "Player 4 \nHP: " + php[3] + "\nStamina: " + pstamina[3];
        tenta.text = "-Tenta-" + "\nHP: " + thp + "\nStamina: " + tstamina + "\nRound: " + round + "\nTurn: " + turn;
    }
}


