using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEvents : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    private float timeBetweenRounds = 2.0f;
    private float nextTime = 0.0f;
    private bool startTimer = false;
    [SerializeField] private GameObject AIPaddle;
    void Start()
    {
        //When game is replayed time scale need to reset
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(startTimer && Time.time > nextTime)
        {
            nextTime = Time.time + 100;
            GameObject temp;
            temp = Instantiate(ball);
            AIPaddle.GetComponent<AIMovement>().enabled = true;
            AIPaddle.GetComponent<AIMovement>().setGameObjectBall(temp);
        }
    }

    public void startNewRound()
    {
        nextTime = Time.time + timeBetweenRounds;
        startTimer = true;
        
    }

}
