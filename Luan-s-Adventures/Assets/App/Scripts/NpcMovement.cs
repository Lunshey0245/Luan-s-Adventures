using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMovement : MonoBehaviour
{
    public float speed = 1.5f;
    private Rigidbody2D rigidBody;
    Animator animator;

    public bool isWalking = false;

    public float walkTime = 1.5f;
    private float walkCounter;

    public float waitTime = 4f;
    private float waitCounter;

    private Vector2[] walkingDirections =
    {
        Vector2.up,Vector2.down,Vector2.left,Vector2.right
    };
    [SerializeField]
    private int currentDirection;

    [SerializeField]
    int lastDirection;

    [SerializeField]
    Transform exitPosition;

    public BoxCollider2D zoneNpc;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        waitCounter = waitTime;
        walkCounter = walkTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isWalking)
        {
            if (exitPosition.transform.position.x < zoneNpc.bounds.min.x ||
                 exitPosition.transform.position.x > zoneNpc.bounds.max.x ||
                 exitPosition.transform.position.y < zoneNpc.bounds.min.y ||
                 exitPosition.transform.position.y > zoneNpc.bounds.max.y)
            {
                StopWalking();
            }
            rigidBody.velocity = walkingDirections[currentDirection] * speed;
            walkCounter -= Time.fixedDeltaTime;
            if (walkCounter < 0)
            {
                StopWalking();
            }
        }
        else
        {
            rigidBody.velocity = Vector2.zero;
            waitCounter -= Time.fixedDeltaTime;
            if (waitCounter < 0)
            {
                StartWalking();
            }
        }
    }

    public void StartWalking()
    {
        if (currentDirection == lastDirection)
        {
            currentDirection = Random.Range(0, walkingDirections.Length);
            if (currentDirection!= lastDirection)
            {
                isWalking = true;
                walkCounter = walkTime;
            }
        }

    }
    public void StopWalking()
    {
        isWalking = false;
        waitCounter = waitTime;
        rigidBody.velocity = Vector2.zero;
        lastDirection = currentDirection;

    }

    private void LateUpdate()
    {
        animator.SetBool("Walking", isWalking);
        animator.SetFloat("Horizontal", walkingDirections[currentDirection].x);
        animator.SetFloat("Vertical", walkingDirections[currentDirection].y);

    }
}
