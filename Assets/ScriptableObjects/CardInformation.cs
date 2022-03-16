using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "New Card", fileName = "CardInformation")]
public class CardInformation : ScriptableObject
{
    public int Damage;
    public int Life;
    public string Name;
    public Sprite Portrait;
    public string Description;
    public int GemsCost;
}