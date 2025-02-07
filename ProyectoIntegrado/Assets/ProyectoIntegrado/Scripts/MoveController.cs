using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] Rigidbody2D objectRb;

    [Header("Collision Check")]
    [SerializeField] Transform collisionCheck;
    [SerializeField] float collisionCheckRadius = 1f;
    [SerializeField] LayerMask collisionLayer;
    [SerializeField] bool isColliding;

    [Header("Horizontal Movement")]
    [SerializeField] bool movesHorizontally;
    [SerializeField] bool isFacingRight;

    [Header("Vertical Movement")]
    [SerializeField] bool movesVertically;
    [SerializeField] bool isFacingUp;

    private void Start()
    {
        objectRb = GetComponent<Rigidbody2D>();
        collisionCheck = GetComponent<Transform>();
    }

    private void Update()
    {
        CollisionCheck();
    }

    private void FixedUpdate()
    {
        if (movesHorizontally == true)
        {

        }

        if (movesVertically == true)
        {

        }
    }

    void MovingH()
    {
        
    }

    void CollisionCheck()
    {
        isColliding = Physics2D.OverlapCircle(collisionCheck.position, collisionCheckRadius, collisionLayer);
    }
}
