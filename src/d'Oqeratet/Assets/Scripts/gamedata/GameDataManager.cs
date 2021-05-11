using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct Board
{
    public int hpTarget { get; set; }
    public Player[] ps  { get; }

    public int activePlayerIndex;

    public List<Card> Assignments;

    public Board(int numPlayers, int hpTarget, Player[] temp_input_ps)
    {
        Debug.Log("Creating Board Struct");

        /*
        Player[] tempPlayers = new Player[numPlayers];

        for(int i = 0; i < numPlayers; i++) {
            tempPlayers[i] = GameObject.Find("Player " + (i+1)).GetComponent<Player>();
        }
        this.ps = tempPlayers;
        */

        //Until Player-prefabbing figured out
        this.ps = temp_input_ps;

        this.hpTarget = hpTarget;
        this.activePlayerIndex = 0;

        int hpSum = 0;
        Assignments = new List<Card>();

        while(hpSum < this.hpTarget) {
            Card newCard = ScriptableObject.CreateInstance<Card>();
            Assignments.Add(newCard);
            hpSum += newCard.hpGain;
        }
    }
}

public class GameDataManager : MonoBehaviour
{

    public Player temp_p1;
    public Player temp_p2;
    public Player temp_p3;
    public Player temp_p4;

    private Board board;
    
    //Constructor
    void Start()
    {
        Debug.Log("Starting GDM");
        Player[] temp_input_ps = new Player[] {temp_p1, temp_p2, temp_p3, temp_p4};
        board = new Board(4, 300, temp_input_ps);
    }

    public void setPlayerTurn(int newActivePlayerIndex) {
        board.activePlayerIndex = newActivePlayerIndex;
    }

    public Player getActivePlayer() {
        return board.ps[board.activePlayerIndex];
    }

    public Player getPlayerFromIndex(int index) {
        return board.ps[index];
    }

    public List<Card> getAssignments() {
        return board.Assignments;
    }

    public Card drawChapterCard() {
        //@Edvin
        return new Card(true);
    }

}