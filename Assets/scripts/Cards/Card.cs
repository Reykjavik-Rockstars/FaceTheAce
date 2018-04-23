using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{

    public new string name;
    public string description;
    public Sprite artwork;

    public Effect effect;
    public Effect GetEffect()
    {
        return effect;
    }
  
}