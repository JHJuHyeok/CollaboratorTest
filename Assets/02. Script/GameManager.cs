using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int Score = 0;
    public TextMeshProUGUI ScoreText;

    public bool isGameOver = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }



    public void AddScore(int amount)
    {
        Score += amount;
        if (ScoreText != null)
            ScoreText.text = $"Score: {Score}";
    }

    public void GameOver()
    {
        if (isGameOver) return;
        SaveData(Score);
        isGameOver = true;
        Debug.Log("Game Over!");
    }

    public void SaveData(int score)
    {
        PlayerPrefs.SetInt("PlayerScore", score);
    }

    public int LoadData()
    {
        return PlayerPrefs.GetInt("PlayerScore");
    }
}