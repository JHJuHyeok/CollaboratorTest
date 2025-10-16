using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;



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
            ScoreText.text = $"Score: {Score}";
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}