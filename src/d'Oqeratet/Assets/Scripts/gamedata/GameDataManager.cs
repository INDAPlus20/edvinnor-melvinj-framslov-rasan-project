using System.Collections;
using System.Collections.Generic;
using UnityEngine;


struct Board
{
    public int hpTarget { get; set; }
    public Player[] ps  { get; }

    public int activePlayerIndex;

    public Board(int numPlayers, int hpTarget)
    {
        Debug.Log("Creating Board Struct");
        Player[] tempPlayers = new Player[numPlayers];

        for(int i = 0; i < numPlayers; i++) {
            tempPlayers[i] = new Player();
        }

        this.hpTarget = hpTarget;
        this.ps = tempPlayers;
        this.activePlayerIndex = 0;
    }
}

public class GameDataManager : ScriptableObject
{

    private Board board;
    
    //Constructor
    public GameDataManager Start()
    {
        Debug.Log("Constructing GDM");
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





}