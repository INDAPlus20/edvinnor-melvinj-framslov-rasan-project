using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card card;
    public Text nameText;
    public Text descriptionText;
    public Image artworkImage;
    public Text hpGainText;
    public Text staminaCostText;
    // Start is called before the first frame update
    void Start()
    {
        /*
        Causing Null Pointers, fix by adding the components in Unity GUI
        nameText.text = card.name;
        descriptionText.text = card.description;
        artworkImage.sprite = card.artwork;
        hpGainText.text = card.hpGain.ToString();
        staminaCostText.text = card.staminaCost.ToString();
        */
    }
}
