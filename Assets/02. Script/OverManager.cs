using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class OverManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    public int score;
    GameManager gm;

    void Start()
    {
        gm = new GameManager();
        score = gm.LoadData();

        scoreText.text = $"Score: {score}";
    }

    public void ReturnToBasic()
    {
        SceneManager.LoadScene("BasicScene");
    }
}
