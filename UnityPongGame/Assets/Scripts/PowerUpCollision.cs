using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCollision : MonoBehaviour
{
    [SerializeField] private GameObject aiPaddle;
    [SerializeField] private GameObject playerPaddle;
    [SerializeField] private GameObject passOnPaddle;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (didThePlayerTouchLast == true)
        {
            passOnPaddle = playerPaddle;
        }
        else
        {
            passOnPaddle = aiPaddle;
        }

        choosePowerUP(passOnPaddle);

        Destroy(this.gameObject);
    }

    static public void playerLastTouch(bool a)
    {
        didThePlayerTouchLast = a;
    }

    public void choosePowerUP(GameObject a)
    {
        powerFreemovement();
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

}
