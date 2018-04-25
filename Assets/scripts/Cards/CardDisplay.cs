using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour {

    public Effect effect;
    public Text nameText;
    public Text descriptionText;
    public Sprite artworkImage;
    public Effect GetEffect()
    {
        return effect;
    }
    //public Text manaText;
    //public Text attackText;
    //public Text healthText;

    // Use this for initialization
    void Start () {
        
        nameText.text = effect.getName;
        descriptionText.text = effect.getDescription;
        artworkImage = effect.getArt;
        
        //manaText.text = card.manaCost.ToString();
        //attackText.text = card.attack.ToString();
        //healthText.text = card.health.ToString();
    }
    
}
