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
    private int num_players;
    
    //Constructor
    void Start()
    {
        Debug.Log("Starting GDM");
        Player[] temp_input_ps = new Player[] {temp_p1, temp_p2, temp_p3, temp_p4};
        this.num_players = 4;
        board = new Board(this.num_players, 300, temp_input_ps);
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
        Debug.Log("NOT IN USE");
        return ScriptableObject.CreateInstance</*Chapter*/Card>();
    }

    public int[] getAllHps() {
        int[] to_return = new int[this.num_players];
        for (int i = 0; i < this.num_players; i++) {
            to_return[i] = getPlayerFromIndex(i).hp;
        }
        return to_return;
    }

    public int[] getAllStaminas() {
        int[] to_return = new int[this.num_players];
        for (int i = 0; i < this.num_players; i++) {
            to_return[i] = getPlayerFromIndex(i).stamina;
        }
        return to_return;
    }

    public int getTurnIndex() {
        return board.activePlayerIndex;
    }

    public void testReference(string reference) {
        Debug.Log("Reference " + reference + " to GDM ok");
    }

}