using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public abstract class Card : ScriptableObject
{
    public Sprite artwork;
    public new string name;
    public string description;

    public abstract bool play(int[] players = null); 
    public abstract bool isPlayable(int[] players = null);   
}
