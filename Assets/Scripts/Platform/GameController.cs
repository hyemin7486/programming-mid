using UnityEngine;
using TMPro;
public class GameController : MonoBehaviour
{

    public static GameController Instance;

    public TextMeshProUGUI text;
    public GameObject clear;
    private float Score = 0;

    private void Awake()
    {
        Instance = this;
    }


    public void AddScore(float value)
    {
        Score += value;
        UpdateUI();
    }


    public void GameClear()
    {
        clear.SetActive(true);
    }


    private void UpdateUI()
    {
        text.text = Score.ToString();
    }
}
