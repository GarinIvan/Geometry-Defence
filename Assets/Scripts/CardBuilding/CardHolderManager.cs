using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardHolderManager : MonoBehaviour
{
    [Header("Card Holder Parameters")]
    [SerializeField] private Transform _cardHolderPosition;
    [SerializeField] private GameObject _card;
    [SerializeField] private Card[] _cardSO;
    private int _cardsAmmount;

    [Header("Card Parameters")]
    [SerializeField] private GameObject[] _plantedCards;
    private int _cost;
    private Image _icon;

    void Start()
    {
        _cardsAmmount = _cardSO.Length;
        _plantedCards = new GameObject[_cardsAmmount];
        for (int i = 0; i < _cardsAmmount; i++)
            CreateCard(i);
    }
    private void CreateCard(int i)
    {
        var card = Instantiate(_card, _cardHolderPosition);
        var image = card.GetComponentInChildren<ImageFound>();
        _icon = image.GetComponent<Image>();
        CardManager cardManager = card.GetComponent<CardManager>();
        
        cardManager.CardSO = _cardSO[i];
        _plantedCards[i] = card;
        _cost = _cardSO[i].cost;
        _icon.sprite = _cardSO[i].imageUI;
        card.GetComponentInChildren<TMP_Text>().text = _cost.ToString();
    }
}
