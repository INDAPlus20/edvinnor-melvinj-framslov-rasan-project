using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : ScriptableObject
{
    public Sprite artwork;
    public int staminaCost; 
    public int hpGain;
    public string name;
    public string description;

    public Card(bool rand = true){
        artwork = null;
        name = "Card";
        description = "description";
        if (rand){
            staminaCost = Random.Range(20, 40);
            hpGain = Random.Range(12, 18);
        }
        else{
            hpGain = 14;
            staminaCost = 30;
        }
    }

    public Card(Sprite artwork, int staminaCost, int hpGain, string name, string description){
        this.artwork = artwork;
        this.staminaCost = staminaCost;
        this.hpGain = hpGain;
        this.name = name;
        this.description = description;
    }
}
