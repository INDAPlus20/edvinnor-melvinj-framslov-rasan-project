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

        player1.text = "Player 1 \nHP: " + players_hp[0] + "\nStamina: " + players_stamina[0];
        player2.text = "Player 2 \nHP: " + players_hp[1] + "\nStamina: " + players_stamina[1];
        player3.text = "Player 3 \nHP: " + players_hp[2] + "\nStamina: " + players_stamina[2];
        player4.text = "Player 4 \nHP: " + players_hp[3] + "\nStamina: " + players_stamina[3];
    }
}


