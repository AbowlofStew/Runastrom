using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float obsPenalty;
    public GameObject fog;
    public float maxdistance = 2;
    public float speedloss = 0.1f;
    public float distance = 1;
    public float waveBonus = 0.1f;
    public float movementLimit = 3;
    public float maxMoveSpeed, minMoveSpeed;
    private float moveSpeed;
    private float currentMovementPosition = 0;
    public GameObject spawnManager;
    private bool surfing;
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
        fog = GameObject.Find("Impending Fog");
    }
	
	// Update is called once per frame
	void Update () {
        if(surfing)
        {
            distance += waveBonus;
        }
        else
        {
            distance -= Time.deltaTime * speedloss;
        }
        if(distance == 0.3)
        {
            Debug.Log("Game Over");
        }
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

            if (!Menu.isPaused)
            {
                this.gameObject.GetComponent<PlayerAnimation>().state = "left";
            }
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

            if (!Menu.isPaused)
            {
                this.gameObject.GetComponent<PlayerAnimation>().state = "right";
            }
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
            this.gameObject.GetComponent<PlayerAnimation>().state = "main";
        }
        if (distance >= maxdistance)
        {
            distance = maxdistance;
        }
            Vector2 vec = Vector2.down + Vector2.left;
            vec.Normalize();
            Vector2 vec2 = new Vector2(0, 0);
            vec = vec2 + vec;
            vec = vec * distance;
            fog.transform.position = new Vector3(vec.x, vec.y, 0);
        
        
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wave")
        {
            spawnManager.GetComponent<WaveHandler>().ChangeSpeed(0);
            spawnManager.GetComponent<ObstacleHandler>().changeSpeed(0.4f);
            surfing = true;
        }
        if ( other.tag == "Obstacle")
        {
            spawnManager.GetComponent<WaveHandler>().ChangeSpeed(0.4f);
            spawnManager.GetComponent<ObstacleHandler>().changeSpeed(0f);
            distance = distance - obsPenalty * Time.deltaTime;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Wave")
        {
            spawnManager.GetComponent<WaveHandler>().ChangeSpeed(0.2f);
            spawnManager.GetComponent<ObstacleHandler>().changeSpeed(0.2f);
            surfing = false;
        }
        if (other.tag == "Obstacle")
        {
            spawnManager.GetComponent<WaveHandler>().ChangeSpeed(0.2f);
            spawnManager.GetComponent<ObstacleHandler>().changeSpeed(0.2f);
            distance = distance - obsPenalty * Time.deltaTime;
        }
    }
    public bool IsSurfing()
    {
        return surfing;
    }

    public void StopSurfing()
    {
        surfing = false;
    }
}
