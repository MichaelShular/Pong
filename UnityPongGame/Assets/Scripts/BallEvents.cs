using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEvents : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    private float timeBetweenRounds = 2.0f;
    private float nextTime = 0.0f;
    private bool startTimer = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(startTimer && Time.time > nextTime)
        {
            nextTime = Time.time + 100;
            Instantiate(ball);
        }
    }

    public void startNewRound()
    {
        nextTime = Time.time + timeBetweenRounds;
        startTimer = true;
        
    }

}