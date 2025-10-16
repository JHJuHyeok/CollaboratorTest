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

        // SpriteRenderer 자동 연결
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
        if (isDead) return;

        //터치 또는 마우스 입력 모두 지원
#if UNITY_EDITOR || UNITY_STANDALONE
        // 에디터나 PC 빌드용: 마우스 클릭으로 테스트
        if (Input.GetMouseButtonDown(0))
        {
            rigd.velocity = Vector2.up * jumpPower;
        }
#else
         //터치 입력으로 점프
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            rigd.velocity = Vector2.up * jumpPower;
        }
#endif
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isDead) return;
        if (other.CompareTag(deathTag))
            HandleDeath(other.gameObject);
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) return;
        if (collision.gameObject.CompareTag(deathTag))
            HandleDeath(collision.gameObject);
    }

    private void HandleDeath(GameObject obstacle)
    {
        if (isDead) return;
        isDead = true;

        
        if (spriteRenderer != null)
            spriteRenderer.flipY = true;

        
        Vector2 v = rigd.velocity;
        v.y = Mathf.Min(v.y, 0f); 
        v.x = 0f;                 
        rigd.velocity = v;

        

        Debug.Log("플레이어가 Grund에 닿음 - 뒤집히고 자연스럽게 떨어짐!");
    }
}
