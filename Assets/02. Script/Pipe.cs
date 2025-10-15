
using System.Runtime.CompilerServices;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.0f;
    [SerializeField] private float moveRange = 0.5f;

    private float startY;
    private bool movingUp = true;
    void Start()
    {
        startY = transform.position.y;
    }

    
    void Update()
    {
        Vector3 pos = transform.position;

        if (movingUp)
            pos.y += moveSpeed * Time.deltaTime;
        else
            pos.y -= moveSpeed * Time.deltaTime;

        transform.position = pos;

        if (pos.y > startY + moveRange)
            movingUp = false;
        else if (pos.y < startY - moveRange)
            movingUp = true;    

    }
}
