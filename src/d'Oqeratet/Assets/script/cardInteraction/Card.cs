using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private int staminaCost {get;}
    private int hpGain {get;}

    public Card(bool rand = true){
        if (rand){
            staminaCost = Random.Range(20, 40);
            hpGain = Random.Range(12, 18);
        }
        else{
            hpGain = 14;
            staminaCost = 30;
        }
    }
}
