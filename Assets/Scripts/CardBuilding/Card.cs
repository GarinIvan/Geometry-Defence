using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Card/New card", fileName = "New card", order = 51)]
public class Card : ScriptableObject
{
    public GameObject prefab;
    public int cost;
    public Image imageUI;
}