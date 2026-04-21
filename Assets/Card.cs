using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card : MonoBehaviour
{
    public TMP_Text cardText;
    public Button button;

    [HideInInspector] public int cardNumber;
    [HideInInspector] public CardGameManager manager;

    private bool isOpened = false;
    private bool isMatched = false;

    public void Setup(int number, CardGameManager gameManager)
    {
        cardNumber = number;
        manager = gameManager;

        isOpened = false;
        isMatched = false;

        CloseCard();

        if (button != null)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(OnCardClicked);
        }
    }

    public void OnCardClicked()
    {
        if (isOpened) return;
        if (isMatched) return;

        OpenCard();
        manager.CardOpened(this);
    }

    public void OpenCard()
    {
        isOpened = true;

        if (cardText != null)
        {
            cardText.text = cardNumber.ToString();
        }
    }

    public void CloseCard()
    {
        isOpened = false;

        if (cardText != null)
        {
            cardText.text = "?";
        }
    }

    public void MatchCard()
    {
        isMatched = true;
        isOpened = true;

        if (button != null)
        {
            button.interactable = false;
        }
    }

    public bool IsOpened()
    {
        return isOpened;
    }

    public bool IsMatched()
    {
        return isMatched;
    }
}