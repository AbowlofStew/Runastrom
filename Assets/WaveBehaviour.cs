using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveBehaviour : MonoBehaviour {
    float timer;
    public float deleteTime = 25;
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
        timer += Time.deltaTime;
        if(timer >= deleteTime)
        {
            selfdestruct();
        }
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
        GameObject.Find("Spawner Manager").GetComponent<WaveHandler>().wavesList.Remove(this.gameObject);   
        Destroy(this.gameObject);
    }
}
