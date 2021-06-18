using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float lockedXPosition = -40.0f;
    void Update()
    {
        //Setting the mouse postion to the players postion
        transform.position = Camera.main.ScreenToWorldPoint( new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
        //Disabling the x movement 
        transform.position = new Vector2(lockedXPosition, transform.position.y); 
    }

}
