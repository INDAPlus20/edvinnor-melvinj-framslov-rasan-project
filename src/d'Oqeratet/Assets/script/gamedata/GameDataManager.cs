using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct Player {
    public int hp {get; set;}
    public int stamina {get; set;}

    private Player(int hp, int stamina) 
    {
        this.hp = hp;
        this.stamina = stamina;
    }
}

struct Board
{
    public int hpTarget { get; set; }
    public Player[] ps  { get; }

    public Board(int numPlayers, int hpTarget)
    {
        Debug.Log("Creating Board Struct");
        Player[] tempPlayers = new Player[numPlayers];

        for(int i = 0; i < numPlayers; i++) {
            tempPlayers[i] = new Player();
        }

        this.hpTarget = hpTarget;
        this.ps = tempPlayers;
    }
}
/*
struct TempExamCard {
    public int staminaCost { get; };
    public int hpBenefit { get; };
}
*/
public class GameDataManager : MonoBehaviour
{
    

    private Board board;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World");
        board = new Board(4, 300);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("We are alive");
    }

    void setHp(int playerindex, int hp) {
        board.ps[playerindex].hp = hp;
    }

    void setStamina(int playerindex, int stamina) {
        board.ps[playerindex].stamina = stamina;
    }

}
