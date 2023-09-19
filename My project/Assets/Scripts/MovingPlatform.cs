using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Transform target; // The range at which the platform will move in.

    Vector2 rightPoint;
    Vector2 leftPoint;
    Vector2 targetPosition;

    [SerializeField] float speed = 2.0f;


    void Start()
    {
        rightPoint.x = target.localPosition.x - (target.localScale.x / 2);
        leftPoint.x = target.localPosition.x + (target.localScale.x / 2);
        
        targetPosition = ChooseRandomDirection();
    }

    void Update()
    {
        // Move the platform towards the next position.
        this.transform.localPosition = Vector2.MoveTowards(this.transform.localPosition, targetPosition, speed * Time.deltaTime);

        // If the platform reaches the next position, switch to the other end.
        if (this.transform.localPosition.x == targetPosition.x)
        {
            // Determine the new next position based on the current position.
            if (targetPosition.x == leftPoint.x)
            {
                targetPosition.x = rightPoint.x;
            }
            else
            {
                targetPosition.x = leftPoint.x;
            }
        }
    }

    Vector2 ChooseRandomDirection()
    {

        int rnd = Random.Range(0, 2);
        Vector2 direction;

        if (rnd == 0)
        {
            direction = new Vector2(rightPoint.x, 0);
        }
        else
        {
            direction = new Vector2(leftPoint.x, 0);
        }

        return direction;
    }
}
