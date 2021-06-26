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

        ChoosePowerUP(passOnPaddle, collision.transform.position);

        Destroy(this.gameObject);
    }

    static public void playerLastTouch(bool a)
    {
        didThePlayerTouchLast = a;
    }

    public void ChoosePowerUP(GameObject a, Vector2 b)
    { 
        int whichPowerUp = Random.Range(0, 7);

        switch(whichPowerUp)
        {
            case 0:
                PowerUpScaleSize(a);
                break;
            case 1:
                PowerDownScaleSize(a);
                break;
            case 2:
                PowerFreemovement();
                break;
            case 3:
                multiShoot(b);
                break;
            case 4:
                SpeedUpBall();
                break;
            case 5:
                ReflectBall();
                break;
            case 6:
                SplitPaddle();
                break;
        }
        
    }

    public void PowerUpScaleSize(GameObject a)
    {
        if (a.transform.localScale.y <= 10)
        {
            a.transform.localScale = new Vector2(1, a.transform.localScale.y + 2);
        }
    }

    public void PowerDownScaleSize(GameObject a)
    {
        if (a.transform.localScale.y >= 2)
        {
            a.transform.localScale = new Vector2(1, a.transform.localScale.y - 2);
        }
    }

    public void PowerFreemovement()
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

    public void SpeedUpBall()
    {
        Vector2 temp = GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody2D>().velocity;
        temp = temp.normalized;
        GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody2D>().AddForce(temp * 50, ForceMode2D.Impulse);
    }

    public void ReflectBall()
    { 
        GameObject temp = GameObject.FindGameObjectWithTag("Ball");
        float speed = temp.GetComponent<Rigidbody2D>().velocity.magnitude;
        Vector3 dir = Vector3.Reflect(temp.GetComponent<Rigidbody2D>().velocity.normalized, temp.GetComponent<Transform>().position.normalized);
        temp.GetComponent<Rigidbody2D>().velocity = dir * speed;
    }
    public void SplitPaddle()
    {
        playerPaddle.GetComponent<SpriteRenderer>().enabled = !playerPaddle.GetComponent<SpriteRenderer>().enabled;
        playerPaddle.GetComponent<BoxCollider2D>().enabled = !playerPaddle.GetComponent<BoxCollider2D>().enabled;

        playerPaddle.transform.GetChild(0).gameObject.SetActive(!playerPaddle.GetComponent<BoxCollider2D>().enabled);
        playerPaddle.transform.GetChild(1).gameObject.SetActive(!playerPaddle.GetComponent<BoxCollider2D>().enabled);
    }
}