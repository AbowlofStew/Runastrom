using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveBehaviour : MonoBehaviour {
    Vector2 isoForward, isoBackward, direction;
    int dir;
    public float movementspeed = 50;

	// Use this for initialization
	void Start () {
        SetUp();
	}
	
	// Update is called once per frame
	void Update () {
        move();
	}
    public void SetUp()
    {
        isoForward = Vector2.up + Vector2.right;
        isoBackward = Vector2.down + Vector2.left;
        isoForward.Normalize();
        isoBackward.Normalize();

        dir = (int)Random.Range(0,1.9f);
        if(dir == 0)
        {

        }
        direction = isoForward;
    }
    public void move()
    {
        transform.Translate(direction * movementspeed * Time.deltaTime);
    }
    public void selfdestruct()
    {

    }
}
