
using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            GameManager.instance.AddScore(1);
            Debug.Log("Score +1 : " + GameManager.instance.Score);
        }
    }
}
