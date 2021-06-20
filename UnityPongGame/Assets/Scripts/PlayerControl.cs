using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float lockedXPosition = -40.0f;
    Rect screenRect = new Rect(0, 0, Screen.width, Screen.height);
    void Update()
    {
        //if (transform.position.y <= 23 && transform.position.y >= -23)
        if (screenRect.Contains(Input.mousePosition))
        {
            //Setting the mouse postion to the players postion
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
            //Disabling the x movement 
            transform.position = new Vector2(lockedXPosition, transform.position.y);
        }
      
    }

}
