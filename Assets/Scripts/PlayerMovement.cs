using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float movementLimit = 3;
    public float maxMoveSpeed, minMoveSpeed;
    private float moveSpeed;
    private float currentMovementPosition = 0;
    public bool collidedWithPlayer;
    public GameObject spawnManager;
    Vector2 isoLeft, isoRight;
    public enum KeysPressed
    {
        NoKeysPressed,
        LeftKeyPressed,
        RightKeyPressed,
        BothKeysPressed
    };
    private KeysPressed LastKeyPressed;

	// Use this for initialization
	void Start () {
        isoLeft = Vector2.up + Vector2.left;
        isoLeft.Normalize();
        moveSpeed = minMoveSpeed;
        isoRight = Vector2.down + Vector2.right;
        isoRight.Normalize();

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) 
            && currentMovementPosition <= movementLimit)
        {
            if (LastKeyPressed == KeysPressed.RightKeyPressed)
            {
                moveSpeed = minMoveSpeed;
            }

            if (moveSpeed < maxMoveSpeed)
            {
                moveSpeed += Time.deltaTime;
            }
            transform.Translate(isoLeft*moveSpeed*Time.deltaTime);
            currentMovementPosition += moveSpeed * Time.deltaTime;
            LastKeyPressed = KeysPressed.LeftKeyPressed;
        }

        if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow)
            && currentMovementPosition >= -1*movementLimit)
        {
            if(LastKeyPressed == KeysPressed.LeftKeyPressed)
            {
                moveSpeed = minMoveSpeed;
            }

            if(moveSpeed< maxMoveSpeed)
            {
                moveSpeed += Time.deltaTime;
            }
            transform.Translate(isoRight*moveSpeed*Time.deltaTime);
            currentMovementPosition -= moveSpeed * Time.deltaTime;
            LastKeyPressed = KeysPressed.RightKeyPressed;
        }

        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            moveSpeed = minMoveSpeed;
            //Move background faster
            LastKeyPressed = KeysPressed.BothKeysPressed;
        }

        if(!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            moveSpeed = minMoveSpeed;
            LastKeyPressed = KeysPressed.NoKeysPressed;
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        spawnManager.GetComponent<WaveHandler>().ChangeSpeed(0);
       
    }

    void OnTriggerExit2D(Collider2D other)
    {
        spawnManager.GetComponent<WaveHandler>().ChangeSpeed(0.2f);
    }

}
