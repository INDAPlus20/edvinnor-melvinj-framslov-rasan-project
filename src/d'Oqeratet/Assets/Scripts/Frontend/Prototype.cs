using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Prototype : MonoBehaviour
{
    private int assignment_hp;
    private int assignment_stamina;

    public TurnManager tm;
    private GameDataManager gdm;
    private AssignmentCard card;

    private int current_round;
    private int current_turn;

    public TMP_Text player1;
    public TMP_Text player2;
    public TMP_Text player3;
    public TMP_Text player4;
    public TMP_Text assignment;

    private int[] players_hp;
    private int[] players_stamina;

    void Start() {
        gdm = GameObject.Find("Game Manager").GetComponent<GameDataManager>();
        //tm = GameObject.Find("Stage Hand").GetComponent<TurnManager>();
    }

    void Update()
    {
        card = gdm.getActivePlayer().getLastAssignment();
        players_hp = gdm.getAllHps();
        players_stamina = gdm.getAllStaminas();
        card = gdm.getActivePlayer().getLastAssignment();
        current_turn = gdm.getTurnIndex();
        current_round = current_turn / 4;
        current_turn++;

        assignment_hp = card.hp;
        assignment_stamina = card.stamina;
        //thp = gamehand.GetComponent<GameObject>;
        //tstamina = gamehand.stamina;

        player1.text = "Player 1 \nHP: " + players_hp[0] + "\nStamina: " + players_stamina[0];
        player2.text = "Player 2 \nHP: " + players_hp[1] + "\nStamina: " + players_stamina[1];
        player3.text = "Player 3 \nHP: " + players_hp[2] + "\nStamina: " + players_stamina[2];
        player4.text = "Player 4 \nHP: " + players_hp[3] + "\nStamina: " + players_stamina[3];

        assignment.text = "-Tenta-" + "\nHP: " + assignment_hp + "\nStamina: " + assignment_stamina + "\nRound: " + current_round + "\nTurn: " + current_turn;
    }
}


