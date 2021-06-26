using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float lockedXPosition = -40.0f;
    [SerializeField] float lockedXPositionForMoveFreely = -10.0f;
    Rect screenRect = new Rect(0, 0, Screen.width, Screen.height);
    static private bool canFreelyMove = false;
    void Update()
    {
        //if (transform.position.y <= 23 && transform.position.y >= -23)
        if (screenRect.Contains(Input.mousePosition))
        {
            //Setting the mouse postion to the players postion
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
            //Disabling the x movement 
            playerMovement();
        }
      
    }
    static public void freeMovementActive(bool a)
    {
        canFreelyMove = a;
    }

    static public bool getCanFreelyMove()
    {
        return canFreelyMove;
    }
    private void playerMovement()
    {
        if (!canFreelyMove)
        {
            transform.position = new Vector2(lockedXPosition, transform.position.y);
            return;
        }
        if (transform.position.x <= -10 && transform.position.x >= -40)
        {
           
            transform.position = new Vector2(transform.position.x, transform.position.y);
        }
        else if(transform.position.x >= -20)
        {
            transform.position = new Vector2(lockedXPositionForMoveFreely, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(lockedXPosition, transform.position.y);
        }
    }
}
