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

    }

    public void playerSetHp(int playerindex, int hp) {
        board.ps[playerindex].hp = hp;
    }

    public void playerSetStamina(int playerindex, int stamina) {
        board.ps[playerindex].stamina = stamina;
    }

    public int playerGetHp(int playerindex) {
        return board.ps[playerindex].hp;
    }

    public int playerGetStamina(int playerindex) {
        return board.ps[playerindex].stamina;
    }

}
