using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    // Script references
    private GameDataManager GDM;

    // Counters
    public int round = 0;
    public int turn = 0;

    // Active turn
    private string choice = "none";
    public int hp;
    public int stamina;

    private void Start()
    {
        // Get GDM reference by name and start loop coroutine
        GDM = GameObject.Find("Game Manager").GetComponent<GameDataManager>();
        StartCoroutine(GameLoop());
    }

    // Used by buttons?
    public void MakeChoice(string input)
    {
        choice = input;
    }

    private IEnumerator GameLoop()
    {
        while (true)
        {
            // Draw new card from active player
            GDM.getActivePlayer().drawCard();

            // Display Assignment card
            yield return WaitForInput();

            // Execute choice
            if (choice == "yes")
            {
                // Prepare for assignment selected
                choice = "none";
                GDM.getActivePlayer().addStamina(-5);

                // Display Chapter-card

                // Do actions, max 3
                int choicesMade = 0;
                while (choicesMade++ < 3) 
                {
                    yield return WaitForInput();
                    if (choice == "study") 
                    {
                        GDM.getActivePlayer().addStamina(-20);
                    }
                    else if (choice == "purchase")
                    {
                        //GDM.getActivePlayer().doStuff();
                    }
                    else if (choice == "chapter event")
                    {
                        //GDM.getActivePlayer().doStuff();
                    }
                    else if (choice == "continue")
                    {   
                        break;
                    }
                }

                // Display Attempt Assignment Option
                yield return WaitForInput();
                if (choice == "yes") 
                {
                    bool finished = GDM.getActivePlayer().getLastAssignment().play();
                    
                    if (finished) 
                    {
                        Debug.Log("Player finished!");
                    }
                }
                else if (choice == "no")
                {

                }
            } 
            else if (choice == "no") 
            {
                choice = "none";

                // Display Work or Relax -Option
                yield return WaitForInput();
                if (choice == "work") 
                {   
                    //GDM.activePlayer.addMoney(500);
                    //GDM.activeplayer.addStamina(-15);
                } 
                else if (choice == "relax") 
                {
                    //GDM.activeplayer.addStamina(25);
                }
            }
            choice = "none";
            

            // Advance turn counter
            if (turn < 3)
            {
                turn++;
            }
            else
            {
                round++;
                turn = 0;
            }

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