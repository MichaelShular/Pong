using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCollision : MonoBehaviour
{
    [SerializeField] private GameObject aiPaddle;
    [SerializeField] private GameObject playerPaddle;
    [SerializeField] private GameObject passOnPaddle;
    [SerializeField] private GameObject ball;
    static private bool didThePlayerTouchLast;

    // Start is called before the first frame update
    void Start()
    {
        playerPaddle = GameObject.FindGameObjectWithTag("Paddle");
        aiPaddle = GameObject.FindGameObjectWithTag("AIPaddle");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (didThePlayerTouchLast == true)
        {
            passOnPaddle = playerPaddle;
        }
        else
        {
            passOnPaddle = aiPaddle;
        }

        choosePowerUP(passOnPaddle, collision.transform.position);

        Destroy(this.gameObject);
    }

    static public void playerLastTouch(bool a)
    {
        didThePlayerTouchLast = a;
    }

    public void choosePowerUP(GameObject a, Vector2 b)
    {
        multiShoot(b);
    }

    public void powerUpScaleSize(GameObject a)
    {
        if (a.transform.localScale.y <= 10)
        {
            a.transform.localScale = new Vector2(1, a.transform.localScale.y + 2);
        }
    }

    public void powerDownScaleSize(GameObject a)
    {
        if (a.transform.localScale.y >= 2)
        {
            a.transform.localScale = new Vector2(1, a.transform.localScale.y - 2);
        }
    }

    public void powerFreemovement()
    {
        PlayerControl.freeMovementActive(!PlayerControl.getCanFreelyMove());
    }

    public void multiShoot(Vector2 a)
    {
        GameObject temp;
        temp = Instantiate(ball);
        temp.GetComponent<Rigidbody2D>().angularVelocity = 10;
        temp.GetComponent<Transform>().position = a;
    }


}
