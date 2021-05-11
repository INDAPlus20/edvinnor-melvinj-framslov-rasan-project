using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Prototype : MonoBehaviour
{
    private int exam_hp;
    private int exam_stamina;

    public TurnManager tm;
    private Card card;

    private int current_round;
    private int current_turn;

    public TMP_Text player1;
    public TMP_Text player2;
    public TMP_Text player3;
    public TMP_Text player4;
    public TMP_Text exam;

    private int[] players_hp;
    private int[] players_stamina;

    void Start() {
        card = tm.card;
    }

    void Update()
    {
        players_hp = new int[] { tm.player1.hp, tm.player2.hp, tm.player3.hp, tm.player4.hp };
        players_stamina = new int[] { tm.player1.stamina, tm.player2.stamina, tm.player3.stamina, tm.player4.stamina };
        current_round = tm.round;
        current_turn = tm.turn;
        current_turn++;

        exam_hp = card.hpGain;
        exam_stamina = card.staminaCost;
        //thp = gamehand.GetComponent<GameObject>;
        //tstamina = gamehand.stamina;

        player1.text = "Player 1 \nHP: " + players_hp[0] + "\nStamina: " + players_stamina[0];
        player2.text = "Player 2 \nHP: " + players_hp[1] + "\nStamina: " + players_stamina[1];
        player3.text = "Player 3 \nHP: " + players_hp[2] + "\nStamina: " + players_stamina[2];
        player4.text = "Player 4 \nHP: " + players_hp[3] + "\nStamina: " + players_stamina[3];
        exam.text = "-Tenta-" + "\nHP: " + exam_hp + "\nStamina: " + exam_stamina + "\nRound: " + current_round + "\nTurn: " + current_turn;
    }
}


