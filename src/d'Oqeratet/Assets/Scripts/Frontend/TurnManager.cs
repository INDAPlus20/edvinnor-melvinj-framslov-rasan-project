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

    public void MakeChoice(string input)
    {
        choice = input;
    }

    private void Start()
    {
        StartCoroutine(GameLoop());
    }

    private IEnumerator GameLoop()
    {
        while (true)
        {
            // ask for card

            // display card
            yield return WaitForInput();
            if (choice == "yes")
            {

            }
            choice = "none";
            // execute result

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