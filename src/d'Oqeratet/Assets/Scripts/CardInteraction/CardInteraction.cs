using System.Collections;
using System.Collections.Generic;
using UnityEngine;
   
public class CardInteraction : ScriptableObject
{
    // Script references
    GameDataManager GDM;
    //FrontEnd FE; Temporarily removed due to errors

    List<Player> players;

    void DoTheThing()
    {
        /*foreach (var p in players)
        {
            if (p.turn && p.card != null){
                GDM.setStamin(p.id, GDM.getStamina() - card.staminaCost);
                GDM.setHP(p.id, GDM.getHP() - card.hpGain);
                p.card = null;
            }
        }*/

        //Replaced O(n) with O(1)

        /*Player cp = GDM.getActivePlayer();
        Card thing = cp.NextAssignment();
        if (thing != null) {
            cp.stamina -= thing.staminaCost;
            cp.hp += thing.hpGain;
            cp.card = null;
        }*/
    }
}
