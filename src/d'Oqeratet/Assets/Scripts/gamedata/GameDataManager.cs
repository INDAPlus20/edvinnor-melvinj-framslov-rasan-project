using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

struct Board
{
    private int hpTarget; //Graduation goal
    public int getHpTarget() {return hpTarget;}

    public Player[] ps; //players
    public int activePlayerIndex; //Index of player currently having their turn
    public List<AssignmentCard> Assignments; //List of all mandatory assignments

    public Board(int numPlayers, int hpTarget, Player[] temp_input_ps, List<AssignmentCard> assignments)
    {
        //Debug.Log("Creating Board Struct");
        //Log in order to find duplicate constructions

        int hpSum = 0;

        foreach (AssignmentCard ac in assignments)
        {
            hpSum += ac.hp;
        }

        this.ps = temp_input_ps;
        this.hpTarget = hpSum;
        this.activePlayerIndex = 0;

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

    public GameObject cardPreFab;
    private GameObject cameraMount;

    void Start()
    {
        Debug.Log("Starting GDM");

        rng = new System.Random();

        string path = @"Assets/Jsons/Assignments.json";

        Player[] temp_input_ps = new Player[] {temp_p1, temp_p2, temp_p3, temp_p4};
        this.num_players = 4;

        board = new Board(this.num_players, 300, temp_input_ps, JsonCardListLoader.ReadPathToAssignmentCardList(path));
        tm.SetActive(true);

        //cardPreFab = Resources.Load<GameObject>("Prefabs/Test Card Disp");
        cameraMount = GameObject.Find("Camera Mount");
        
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

    //In future:
    //Will Create a GameObject from players AssignmentCard
    public AssignmentCard drawPlayerCard() 
    {
        Player player = getActivePlayer();
        AssignmentCard assignment = player.drawCard();
        Transform playerCard = player.transform.Find("Test Card Disp(Clone)");

        // If no playerCard is found, Create GameObject
        if (playerCard == null) 
        {
            Vector3 pos = new Vector3(0, 1.35f, 0); // Temp
            playerCard = Instantiate<GameObject>(cardPreFab, pos, cameraMount.transform.rotation * Quaternion.Euler(0, 0, 90)).transform;
            playerCard.parent = player.transform;
        }

        // Get text-fields
        Transform canvas = playerCard.transform.Find("Canvas");
        Transform title = canvas.transform.Find("Title");
        Transform sa = canvas.transform.Find("Splash Art");
        Transform ft = canvas.transform.Find("Flavour Text");
        Transform hp = canvas.transform.Find("HP");
        Transform stamina = canvas.transform.Find("Stamina");

        // Update text-fields
        title.GetComponent<TMPro.TextMeshProUGUI>().text = assignment.name;
        //sa.GetComponent<Image>().SourceImage = assignment.artwork; // Uncertain of this one
        ft.GetComponent<TMPro.TextMeshProUGUI>().text = assignment.description;
        hp.GetComponent<TMPro.TextMeshProUGUI>().text = assignment.hp.ToString();
        stamina.GetComponent<TMPro.TextMeshProUGUI>().text = Mathf.Abs(assignment.stamina).ToString();

        return assignment;
    }

    public ChapterCard drawChapterCard() 
    {
        //@Edvin
        Debug.Log("NOT IN USE");
        return ScriptableObject.CreateInstance<ChapterCard>();
    }

    public int getHpTarget() 
    {
        return board.getHpTarget();
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

    //Returns an array of player balances
    public int[] getAllBalances() 
    {
        int[] to_return = new int[this.num_players];
        for (int i = 0; i < this.num_players; i++) 
        {
            to_return[i] = getPlayerFromIndex(i).money;
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
