using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpwner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnInterval = 3.0f;
    public float minY = -5.0f;
    public float maxY = 5.0f;
    private float timer = 0.0f;
    public
    void Update()
    {
        if (GameManager.instance != null && GameManager.instance.isGameOver)
            return;

        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnPipe();
            timer = 0.0f;
        }
    }
    
    void SpawnPipe()
    {
        
            float randomY = Random.Range(minY, maxY);
            Vector2 spawnPos = new Vector3(transform.position.x, randomY);
            
            pipePrefab = Instantiate(pipePrefab, spawnPos, Quaternion.identity);
       
       

    }

    
}
