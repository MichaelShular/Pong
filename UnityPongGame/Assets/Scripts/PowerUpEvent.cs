using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpEvent : MonoBehaviour
{
    [SerializeField] private GameObject powerUp;
    [SerializeField] private float minXAxis = -15;
    [SerializeField] private float maxXAxis = 15;
    [SerializeField] private float minYAxis = -20;
    [SerializeField] private float maxYAxis = 20;
    private float timeUNtilNextPowerUp = 15.0f;
    private float nextTime = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        nextTime = Time.time + timeUNtilNextPowerUp;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextTime)
        {
            nextTime = Time.time + timeUNtilNextPowerUp;

            Transform temp = this.transform;
            temp.position = new Vector2(Random.Range(minXAxis, maxXAxis), Random.Range(minYAxis, maxYAxis));
            Instantiate(powerUp, temp);


        }
    }
}
