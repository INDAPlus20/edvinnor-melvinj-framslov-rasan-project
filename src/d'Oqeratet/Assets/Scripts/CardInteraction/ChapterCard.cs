using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Chapter Card", menuName = "Chapter")]
public class ChapterCard : ScriptableObject
{
    public Sprite artwork;
    public new string name;
    public string description;

    //Give negative values for lossing stats
    public int[] stamina;
    public int[] money;
    public int[] time;  //if theres extra time cost for doing the chapter

    public ChapterCard(Sprite artwork, int[] money, int[] stamina, string name, string description){
        Debug.Log("card created");
        this.artwork = artwork;
        this.name = name;
        this.description = description;

        this.stamina = stamina;
        this.money = money;
    }
    //provide the player id's in the order of the stat arrays
    public void play(int[] players){ 
        GameDataManager gdm = GameObject.Find("Game Manager").GetComponent<GameDataManager>();
        for (int i = 0; i < players.Length; i++){
            gdm.getPlayerFromIndex(players[i]).addStamina(stamina[i]);
            gdm.getPlayerFromIndex(players[i]).addMoney(stamina[i]);
        }
    }
}
