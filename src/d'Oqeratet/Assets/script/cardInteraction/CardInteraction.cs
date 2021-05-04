using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct player {
    int id {get;}   //witch player
    bool turn {get; set;}   //is it his turn (may be yeeted if everyone has a turn at the same time)
    Card card {get; set;}   //what card has the player picked (null if no card is picked)
    public Player(int id){
        this.id = id;
        turn = false;
        card = null;
    }
}   
public class CardInteraction : MonoBehaviour
{
    // Script references
    GameDataManager GDM;
    FrontEnd FE;

    List<Player> players;
    // Start is called before the first frame update
    void Start()
    {
        //initilise players or something discuss further with team
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var p in players)
        {
            if (p.turn && p.card != null){
                GDM.setStamin(p.id, GDM.getStamina() - card.staminaCost)
                GDM.setHP(p.id, GDM.getHP() - card.hpGain)
            }
        }
    }
}
