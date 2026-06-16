using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    private float currentTime = 60f;

    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            currentTime = 0;
            GameController.Instance.ShowGameOver();
        }

        timerText.text = Mathf.Ceil(currentTime).ToString();
    }
}