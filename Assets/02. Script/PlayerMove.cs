using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rigd;

    [Header("Jump")]
    public float jumpPower = 7f;

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

        

        Debug.Log("ÇÃ·¹ÀÌ¾î°¡ Grund¿¡ ´êÀ½ - µÚÁýÈ÷°í ¶³¾îÁü!");

        
    }
}
