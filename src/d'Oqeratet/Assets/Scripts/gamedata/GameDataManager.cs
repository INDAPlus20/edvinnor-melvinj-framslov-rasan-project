using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct Board
{
    public int hpTarget { get; set; }
    public Player[] ps  { get; }

    public int activePlayerIndex;

    public List<Card> Assignments;

    public Board(int numPlayers, int hpTarget)
    {
        Debug.Log("Creating Board Struct");
        Player[] tempPlayers = new Player[numPlayers];

        for(int i = 0; i < numPlayers; i++) {
            tempPlayers[i] = GameObject.Find("Player " + (i+1)).GetComponent<Player>();
        }

        this.hpTarget = hpTarget;
        this.ps = tempPlayers;
        this.activePlayerIndex = 0;

        int hpSum = 0;
        Assignments = new List<Card>();

        while(hpSum < this.hpTarget) {
            Card newCard = new Card(true);
            Assignments.Add(newCard);
            hpSum += newCard.hpGain;
        }
    }
}

public class GameDataManager : MonoBehaviour
{

    private Board board;
    
    //Constructor
    void Start()
    {
        Debug.Log("Starting GDM");
        board = new Board(4, 300);
    }

    public int nextPlayerTurn() {
        board.activePlayerIndex++;
        if(board.activePlayerIndex >= board.ps.Length) {
            board.activePlayerIndex = 0;
        }
        return board.activePlayerIndex;
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