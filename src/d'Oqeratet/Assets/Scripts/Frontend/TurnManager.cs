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

    public Card card;
    public Card assignment;

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

            //Get active player's assignment card
            //Causes issues since there currently (05-11) is no Card prefab
            card = active_player.drawCard();


            // ask for card TODO when cards are set up

            // display card TODO when cards are set up

            // execute result
            yield return WaitForInput();
            if (choice == "yes")
            {
                active_player.addHP(card.hpGain);
                active_player.addStamina(-card.staminaCost);
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