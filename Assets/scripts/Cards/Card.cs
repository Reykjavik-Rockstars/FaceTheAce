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
    // 0.0 rare - 1.0 common!
    public struct Rarity
    {
        public const double Common = 0.5;
        public const double UnCommon = 0.25;
        public const double Rare = 0.15;
        public const double Epic = 0.08;
        public const double Legendary = 0.02;
    };
}