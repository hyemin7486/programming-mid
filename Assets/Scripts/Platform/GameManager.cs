using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject gameOverPanel;

    public TMP_Text timerText;

    public float timeLimit = 60f;

    private float currentTime;

    bool isGameOver = false;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        currentTime = timeLimit;

        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (isGameOver) return;

        currentTime -= Time.deltaTime;

        timerText.text =
            "Time : " + Mathf.Ceil(currentTime);

        if (currentTime <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;

        gameOverPanel.SetActive(true);

        Time.timeScale = 0f;
    }
}