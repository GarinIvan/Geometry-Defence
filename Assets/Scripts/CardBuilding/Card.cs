using UnityEngine;

[CreateAssetMenu(menuName = "Card/New card", fileName = "New card", order = 51)]
public class Card : ScriptableObject
{
    public GameObject prefab;
    public int cost;
    public float timeToReload;
    public Sprite imageUI;
}