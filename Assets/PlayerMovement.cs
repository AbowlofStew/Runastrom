using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float movementLimit = 3;
    public float maxMoveSpeed, minMoveSpeed;
    public float moveSpeed;
    public float currentMovementPosition = 0;

    Vector2 isoLeft, isoRight;

	// Use this for initialization
	void Start () {
        isoLeft = Vector2.up + Vector2.left;
        isoLeft.Normalize();

        isoRight = Vector2.down + Vector2.right;
        isoRight.Normalize();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) 
            && currentMovementPosition <= movementLimit)
        {
            transform.Translate(isoLeft*moveSpeed*Time.deltaTime);
            currentMovementPosition += moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow)
            && currentMovementPosition >= -1*movementLimit)
        {
            transform.Translate(isoRight*moveSpeed*Time.deltaTime);
            currentMovementPosition -= moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            //Move background faster
        }
    }
}
