using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class DeathBox : MonoBehaviour
{
    private int directionDecider;
    [SerializeField] private float boxSpeed;
    private float oppositeBoxSpeed;
    private float originalBoxSpeed;
    
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform deathBox;
    [SerializeField] private Transform leftIndicator;
    [SerializeField] private Transform rightIndicator;
    
    [SerializeField] private float speedIncreaseAmount;
    [SerializeField] private float currentSpeedMultiplier = 1f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalBoxSpeed = boxSpeed;
        oppositeBoxSpeed = boxSpeed * -1;
        LeftOrRight();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector2(boxSpeed, rb.linearVelocity.y);
    }

    void LeftOrRight()
    {
        directionDecider = Random.Range(0, 2);
        print(directionDecider);

        if (directionDecider == 0)
        {
            //Make sure the Death Box goes left.
            deathBox.transform.position = rightIndicator.transform.position;
            boxSpeed = oppositeBoxSpeed * currentSpeedMultiplier;
        }
        else if (directionDecider == 1)
        {
            //Make sure the Death Box goes right.
            deathBox.transform.position = leftIndicator.transform.position;
            boxSpeed = originalBoxSpeed * currentSpeedMultiplier;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Switch"))
        {
            if (currentSpeedMultiplier < 10)
            {
                currentSpeedMultiplier += speedIncreaseAmount;
            }

            LeftOrRight();
            AvoidDangerCounter.instance.UpdateCounterText();
        }
    }
}
