using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    private Rigidbody2D body;
    private Vector3 lastVel;
    private GameObject AIPaddle;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        AIPaddle = GameObject.FindGameObjectWithTag("AIPaddle");
    }

    // Update is called once per frame
    void Update()
    {
        lastVel = body.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Goal")
        {
            GameObject.Find("GameEvents").GetComponent<BallEvents>().startNewRound();
            AIPaddle.GetComponent<AIMovement>().enabled = false;
            Destroy(this.gameObject);
            return;
        }

        float speed = lastVel.magnitude;
        Vector3 dir = Vector3.Reflect(lastVel.normalized, collision.GetContact(0).normal);
        body.velocity = dir * speed;
    
    }
}
