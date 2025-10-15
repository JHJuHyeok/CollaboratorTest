
using System.Runtime.CompilerServices;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float moveXSpeed = 2.0f;
    [SerializeField] private float moveYSpeed = 2.0f;
    [SerializeField] private float moveRange = 0.5f;
    [SerializeField] private float lifeTime = 10.0f;

    private float startY;
    private bool movingUp = true;
    private float timer = 0.0f;
    void Start()
    {
        startY = transform.position.y;
    }

    
    void Update()
    {
        Vector3 pos = transform.position;

        if (movingUp)
            pos.y += moveYSpeed * Time.deltaTime;
        else
            pos.y -= moveYSpeed * Time.deltaTime;

        transform.position = pos;

        if (pos.y > startY + moveRange)
            movingUp = false;
        else if (pos.y < startY - moveRange)
            movingUp = true;


        pos.x -= moveXSpeed * Time.deltaTime;

        transform.position = pos;

        timer += Time.deltaTime;
        if (timer >= lifeTime)
        {
            Destroy(gameObject);
        }

    }
}
