using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    
    public int round = 0;
    public int turn = 0;
    private string choice = "none";
    public int hp;
    public int stamina;

    public Player player1;
    public Player player2;
    public Player player3;
    public Player player4;

    public Card card;
    public Card exam;

    private GameDataManager GDM;

    public void MakeChoice(string input)
    {
        choice = input;
    }

    private void Start()
    {
        GDM = GameObject.Find("Game Manager").GetComponent<GameDataManager>();
        StartCoroutine(GameLoop());
    }

    private IEnumerator GameLoop()
    {

        while (true)
        {
            //Get active player from GDM
            Player active_player = GDM.getActivePlayer();

            //Get active player's exam card
            //Causes issues since there currently (05-11) is no Card prefab
            /*exam = active_player.drawCard();*/


            // ask for card TODO when cards are set up

            // display card TODO when cards are set up

            // execute result
            yield return WaitForInput();
            if (choice == "yes")
            {
                active_player.addHP(card.hpGain);
                active_player.addStamina(-card.staminaCost);
                /*switch (turn) {
                    case 0:
                        player1.hp += card.hpGain;
                        player1.stamina -= card.staminaCost;
                        break;
                    case 1:
                        player2.hp += card.hpGain;
                        player2.stamina -= card.staminaCost;
                        break;
                    case 2:
                        player3.hp += card.hpGain;
                        player3.stamina -= card.staminaCost;
                        break;
                    case 3:
                        player4.hp += card.hpGain;
                        player4.stamina -= card.staminaCost;
                        break;
                }*/
            }
            choice = "none";

            // advance
            if (turn < 3)
            {
                turn++;
            }
            else
            {
                round++;
                turn = 0;
            }

            //Updates GDM with the next turn
            GDM.setPlayerTurn(turn);
        }
    }

    private IEnumerator WaitForInput()
    {
        while (true)
        {
            if (choice != "none")
            {
                break; // <--- Debug here!!!
            }
            yield return null;
        }
    }
}