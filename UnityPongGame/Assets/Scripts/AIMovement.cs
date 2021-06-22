using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float movespeed = 15;
    [SerializeField] private GameObject ball;
    private float yAxisDiff;
    private float stopMovingNum = 0.5f;
    enum AIChaseState { moveUp, moveDown, Stay }
    private AIChaseState whatState;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        whatState = AIChaseState.Stay;
    }

    private void FixedUpdate()
    { 
        yAxisDiff = transform.position.y - ball.transform.position.y;

        checkWhichState(yAxisDiff);

        switch (whatState)
        {
            case AIChaseState.moveUp:
                body.velocity = Vector2.up * movespeed;
                break;
            case AIChaseState.moveDown:
                body.velocity = Vector2.down * movespeed;
                break;
            case AIChaseState.Stay:
                body.velocity = Vector2.zero * movespeed;
                break;
            default:
                break;
        }
       
    }
    private void checkWhichState(float a)
    {
        if(a < stopMovingNum)
        {
            whatState = AIChaseState.moveUp;
            return;
        }
        if (a > -stopMovingNum)
        {
            whatState = AIChaseState.moveDown;
            return;
        }
        whatState = AIChaseState.Stay;
    }

    public void setGameObjectBall(GameObject a)
    {
        ball = a;
    }
        

}
