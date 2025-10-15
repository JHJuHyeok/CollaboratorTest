using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int Score = 0;
    public TextMeshProUGUI ScoreText;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void AddScore(int amount)
    {
        Score += amount;
        if (ScoreText != null)
            ScoreText.text = Score.ToString();
    }
}