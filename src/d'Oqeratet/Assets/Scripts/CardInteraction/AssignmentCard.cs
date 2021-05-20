using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Assignment Card", menuName = "Assignment")]
[Serializable]
public class AssignmentCard : ScriptableObject
{
    public Sprite artwork;
    public new string name;
    public string description;

    //Give negative values for lossing stats
    public int stamina;
    public int hp;

    public void OnEnable()
    {
        if (true)
        {
            stamina = UnityEngine.Random.Range(-40, -20);
            hp = UnityEngine.Random.Range(18, 12);
        }
    }

    public AssignmentCard(bool rand = true){
        artwork = null;
        name = "Card";
        description = "description";
        if (rand){
            stamina = UnityEngine.Random.Range(-40, -20);
            hp = UnityEngine.Random.Range(18, 12);
        }
        else{
            hp = 14;
            stamina = -30;
        }
    }

    public AssignmentCard InitAndReturnSelf(Sprite artwork, int stamina, int hp, string name, string description) {
        this.artwork = artwork;
        this.stamina = stamina;
        this.hp = hp;
        this.name = name;
        this.description = description;
        return this;
    }

    public AssignmentCard(Sprite artwork, int stamina, int hp, string name, string description){
        Debug.Log("card created");
        this.artwork = artwork;
        this.stamina = stamina;
        this.hp = hp;
        this.name = name;
        this.description = description;
    }

    public void play(){ 
        GameDataManager gdm = GameObject.Find("Game Manager").GetComponent<GameDataManager>();
        gdm.getActivePlayer().addStamina(stamina);
        gdm.getActivePlayer().addHP(hp);
    }

    public bool isPlayable(){
        GameDataManager gdm = GameObject.Find("Game Manager").GetComponent<GameDataManager>();
        var player = gdm.getActivePlayer();
        newStamina = player.stamina + stamina;
        newHp = player.hp + hp;
        return !(newStamina < 0) && !(player.maxStamina < newStamina);
    }

    public string ToJson()
    {
        return JsonUtility.ToJson(this);
    }
}
