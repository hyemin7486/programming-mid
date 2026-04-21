using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGameManager : MonoBehaviour
{
    [Header("연결할 것")]
    public Transform cardArea;
    public GameObject cardPrefab;

    [Header("페어 개수")]
    public int pairCount = 4;

    private List<Card> cardList = new List<Card>();

    private Card firstCard = null;
    private Card secondCard = null;

    private bool isChecking = false;

    void Start()
    {
        CreateCards();
    }

    public void CreateCards()
    {
        ClearCards();

        List<int> numbers = new List<int>();

        for (int i = 1; i <= pairCount; i++)
        {
            numbers.Add(i);
            numbers.Add(i);
        }

        Shuffle(numbers);

        for (int i = 0; i < numbers.Count; i++)
        {
            GameObject newCardObj = Instantiate(cardPrefab, cardArea);
            Card newCard = newCardObj.GetComponent<Card>();

            if (newCard != null)
            {
                newCard.Setup(numbers[i], this);
                cardList.Add(newCard);
            }
        }
    }

    public void CardOpened(Card openedCard)
    {
        if (isChecking) return;

        if (firstCard == null)
        {
            firstCard = openedCard;
            return;
        }

        if (secondCard == null)
        {
            secondCard = openedCard;
            StartCoroutine(CheckMatch());
        }
    }

    IEnumerator CheckMatch()
    {
        isChecking = true;

        yield return new WaitForSeconds(0.8f);

        if (firstCard.cardNumber == secondCard.cardNumber)
        {
            firstCard.MatchCard();
            secondCard.MatchCard();
        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
        }

        firstCard = null;
        secondCard = null;
        isChecking = false;
    }

    void Shuffle(List<int> numbers)
    {
        for (int i = 0; i < numbers.Count; i++)
        {
            int randomIndex = Random.Range(i, numbers.Count);

            int temp = numbers[i];
            numbers[i] = numbers[randomIndex];
            numbers[randomIndex] = temp;
        }
    }

    public void ClearCards()
    {
        for (int i = 0; i < cardList.Count; i++)
        {
            if (cardList[i] != null)
            {
                Destroy(cardList[i].gameObject);
            }
        }

        cardList.Clear();
        firstCard = null;
        secondCard = null;
        isChecking = false;
    }
}
