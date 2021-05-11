using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct Board
{
    public int hpTarget; //Graduation goal
    public Player[] ps; //players
    public int activePlayerIndex; //Index of player currently having their turn
    public List<Card> Assignments; //List of all mandatory exams

    public Board(int numPlayers, int hpTarget, Player[] temp_input_ps)
    {
        Debug.Log("Creating Board Struct");
        //Logs in order to find duplicate constructions


        /*
        Until player-prefabbing figured out this is commented out
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

        //Generate more exams until we have an entire deck surpassing the graduation goal
        while(hpSum < this.hpTarget) 
        {
            Card newCard = ScriptableObject.CreateInstance<Card>();
            Assignments.Add(newCard);
            hpSum += newCard.hpGain;
        }
    }
}

public class GameDataManager : MonoBehaviour
{

    //Added through unity GUI
    public Player temp_p1;
    public Player temp_p2;
    public Player temp_p3;
    public Player temp_p4;

    private Board board;
    private int num_players;
    

    void Start()
    {
        Debug.Log("Starting GDM");

        Player[] temp_input_ps = new Player[] {temp_p1, temp_p2, temp_p3, temp_p4};
        this.num_players = 4;

        board = new Board(this.num_players, 300, temp_input_ps);
    }

    //Set the index of the player currently having their turn
    public void setPlayerTurn(int newActivePlayerIndex) 
    {
        board.activePlayerIndex = newActivePlayerIndex;
    }

    //Returns a reference to the player object currently having their turn
    public Player getActivePlayer() 
    {
        return board.ps[board.activePlayerIndex];
    }

    //Returns a reference with the index specified
    public Player getPlayerFromIndex(int index) 
    {
        return board.ps[index];
    }

    //Returns the global list of exams
    public List<Card> getAssignments() 
    {
        return board.Assignments;
    }

    //In future:
    //Will return the next chapter card from the global deck
    public Card drawChapterCard() 
    {
        //@Edvin
        Debug.Log("NOT IN USE");
        return ScriptableObject.CreateInstance</*Chapter*/Card>();
    }

    //Returns an array of player hp-s
    public int[] getAllHps() 
    {
        int[] to_return = new int[this.num_players];
        for (int i = 0; i < this.num_players; i++) 
        {
            to_return[i] = getPlayerFromIndex(i).hp;
        }
        return to_return;
    }

    //Returns an array of player staminas
    public int[] getAllStaminas() 
    {
        int[] to_return = new int[this.num_players];
        for (int i = 0; i < this.num_players; i++) 
        {
            to_return[i] = getPlayerFromIndex(i).stamina;
        }
        return to_return;
    }

    //Returns the current turn index
    public int getTurnIndex() 
    {
        return board.activePlayerIndex;
    }

    //Call this method to find out if your reference to GDM is OK
    //Remove when unneccessary
    public void testReference(string reference) 
    {
        Debug.Log("Reference " + reference + " to GDM ok");
    }

}