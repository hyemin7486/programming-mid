using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public TextMeshProUGUI text;
    public GameObject clear;
    public GameObject gameOver;

    private float Score = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1f;

        clear.SetActive(false);
        gameOver.SetActive(false);
    }

    public void AddScore(float value)
    {
        Score += value;
        UpdateUI();
    }

    public void GameClear()
    {
        clear.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f;
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f;
    }

    private void UpdateUI()
    {
        text.text = Score.ToString();
    }
}