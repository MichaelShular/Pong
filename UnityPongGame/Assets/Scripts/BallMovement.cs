using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 20;
    private int xAxisPosativeOrNegative = 1;
    private int yAxisPosativeOrNegative = 1;
    private Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        transform.position = new Vector2(0, Random.Range(-20.0f, 20.0f));
        xAxisPosativeOrNegative = Random.value < 0.5f ? 1 : -1;
        yAxisPosativeOrNegative = Random.value < 0.5f ? 1 : -1;
        body.velocity = new Vector2(Mathf.Sin(45) * movementSpeed * xAxisPosativeOrNegative,
          Mathf.Cos(45) * movementSpeed * yAxisPosativeOrNegative);
    }

    // Update is called once per frame
    void Update()
    {


    }

}
