using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Assignment Card", menuName = "Assignment")]
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
            stamina = Random.Range(-40, -20);
            hp = Random.Range(18, 12);
        }
    }

    public AssignmentCard(bool rand = true){
        artwork = null;
        name = "Card";
        description = "description";
        if (rand){
            stamina = Random.Range(-40, -20);
            hp = Random.Range(18, 12);
        }
        else{
            hp = 14;
            stamina = -30;
        }
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
}
