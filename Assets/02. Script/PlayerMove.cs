using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rigd;

    [Header("Jump")]
    public float jumpPower = 7f;
    public AudioSource jumpSfx;
    public AudioClip jumpSound;

    [Header("Death / Collision")]
    public string deathTag = "Grund";        
    public SpriteRenderer spriteRenderer;   
    public bool isDead = false;

    void Start()
    {
        rigd = GetComponent<Rigidbody2D>();

        
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }

    void Update()
    {
        
        if (isDead) return;

        if (Input.GetMouseButtonDown(0))
        {
            rigd.velocity = Vector2.up * jumpPower;

            JumpSound();
        }
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isDead) return;

        if (other.CompareTag(deathTag))
        {
            HandleDeath(other.gameObject);
        }
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) return;

        if (collision.gameObject.CompareTag(deathTag))
        {
            HandleDeath(collision.gameObject);
        }
    }

    private void HandleDeath(GameObject obstacle)
    {
        if (isDead) return;
        isDead = true;

        
        if (spriteRenderer != null)
        {
            spriteRenderer.flipY = true;  
        }

        
        Vector2 v = rigd.velocity;
        v.y = Mathf.Min(v.y, 0f); 
        v.x = 0f;                 
        rigd.velocity = v;

        if (GameManager.instance != null)
        {
            GameManager.instance.GameOver();
            Debug.Log("[PlayerMove] Player hit ground -> GameOver called");
        }

        Debug.Log("플레이어가 Grund에 닿음 - 뒤집히고 떨어짐!");

        StartCoroutine(LoadOverScene());
    }

    public void JumpSound()
    {
        jumpSfx.PlayOneShot(jumpSound);
    }
    IEnumerator LoadOverScene()
    {
        yield return new WaitForSeconds(1f); // 1초 기다렸다가
        SceneManager.LoadScene("Over");      // "Over"라는 씬으로 이동
    }
}
