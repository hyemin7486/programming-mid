using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Card : MonoBehaviour
{
    public TMP_Text cardText;
    public Button button;

    [HideInInspector] public int cardNumber;
    [HideInInspector] public CardGameManager manager;

    private bool isOpened = false;
    private bool isMatched = false;
    private bool isFlipping = false;

    public void Setup(int number, CardGameManager gameManager)
    {
        cardNumber = number;
        manager = gameManager;

        isOpened = false;
        isMatched = false;
        isFlipping = false;

        transform.localScale = Vector3.one;

        if (cardText != null)
        {
            cardText.text = "";
            cardText.gameObject.SetActive(false);
        }

        if (button != null)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(OnCardClicked);
            button.interactable = true;
        }
    }

    public void OnCardClicked()
    {
        if (isOpened) return;
        if (isMatched) return;
        if (isFlipping) return;

        OpenCard();
        manager.CardOpened(this);
    }

    public void OpenCard()
    {
        StartCoroutine(FlipOpen());
    }

    public void CloseCard()
    {
        StartCoroutine(FlipClose());
    }

    public void MatchCard()
    {
        isMatched = true;
        isOpened = true;

        if (button != null)
            button.interactable = false;
    }

    public bool IsOpened()
    {
        return isOpened;
    }

    public bool IsMatched()
    {
        return isMatched;
    }

    IEnumerator FlipOpen()
    {
        isFlipping = true;

        yield return StartCoroutine(ScaleX(0f));

        if (cardText != null)
        {
            cardText.gameObject.SetActive(true);
            cardText.text = cardNumber.ToString();
        }

        yield return StartCoroutine(ScaleX(1f));

        isOpened = true;
        isFlipping = false;
    }

    IEnumerator FlipClose()
    {
        isFlipping = true;

        yield return StartCoroutine(ScaleX(0f));

        if (cardText != null)
        {
            cardText.text = "";
            cardText.gameObject.SetActive(false);
        }

        yield return StartCoroutine(ScaleX(1f));

        isOpened = false;
        isFlipping = false;
    }

    IEnumerator ScaleX(float targetX)
    {
        float duration = 0.12f;
        float time = 0f;

        Vector3 startScale = transform.localScale;
        Vector3 targetScale = new Vector3(targetX, 1f, 1f);

        while (time < duration)
        {
            time += Time.deltaTime;
            transform.localScale = Vector3.Lerp(startScale, targetScale, time / duration);
            yield return null;
        }

        transform.localScale = targetScale;
    }
}