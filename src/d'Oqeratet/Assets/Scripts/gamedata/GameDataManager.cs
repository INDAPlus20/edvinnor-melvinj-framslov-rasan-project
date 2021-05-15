using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

struct Board
{
    public int hpTarget; //Graduation goal
    public Player[] ps; //players
    public int activePlayerIndex; //Index of player currently having their turn
    public List<AssignmentCard> Assignments; //List of all mandatory assignments

    public Board(int numPlayers, int hpTarget, Player[] temp_input_ps, List<AssignmentCard> assignments)
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
        Assignments = assignments;
    }
}

public class GameDataManager : MonoBehaviour
{
    private System.Random rng;

    //Added through unity GUI
    public Player temp_p1;
    public Player temp_p2;
    public Player temp_p3;
    public Player temp_p4;
    public GameObject tm;

    private Board board;
    private int num_players;
    

    void Start()
    {
        Debug.Log("Starting GDM");

        rng = new System.Random();

        string path = @"Assets/Jsons/Assignments.json";

        Player[] temp_input_ps = new Player[] {temp_p1, temp_p2, temp_p3, temp_p4};
        this.num_players = 4;

        board = new Board(this.num_players, 300, temp_input_ps, AssignmentCardLoader.ReadAssignments(path));
        tm.SetActive(true);
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

    //Returns the global list of assignments
    public List<AssignmentCard> getAssignments() 
    {
        if (board.Assignments == null) {
            Debug.Log("Assignments null when getting assignments");
        }
        try 
        {
            List<AssignmentCard> tempassignments;
            
            //Deep Copy Magic
            tempassignments = board.Assignments.ConvertAll(c => ScriptableObject.CreateInstance<AssignmentCard>().InitAndReturnSelf(c.artwork, c.stamina, c.hp, c.name, c.description));
            Shuffle(tempassignments);
            return tempassignments;
        }
        catch (NullReferenceException) {
            return null;
        }
    }

    //In future:
    //Will return the next chapter card from the global deck
    public AssignmentCard drawChapterCard() 
    {
        //@Edvin
        Debug.Log("NOT IN USE");
        return ScriptableObject.CreateInstance</*Chapter*/AssignmentCard>();
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

    public void Shuffle<T>(List<T> list)  
    {
        int n = list.Count;  
        while (n > 1) {  
            n--;  
            int k = rng.Next(n + 1);  
            T value = list[k];  
            list[k] = list[n];  
            list[n] = value;  
        }  
    }

}