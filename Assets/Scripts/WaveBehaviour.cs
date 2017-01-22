using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveBehaviour : MonoBehaviour {
    float timer;
    public float deleteTime = 25;
    Vector2 isoForward, isoBackward, direction;
    int dir;
    public float movementspeed = 50;
    public GameObject spawnManager;

    private bool collidingWithPlayer = false;

    // Use this for initialization
    void Start () {
        SetUp();
        deleteTime = Random.Range(3, 20);
        spawnManager = GameObject.FindGameObjectWithTag("GameController");
	}
	
	// Update is called once per frame
	void Update () {
        move();
        timer += Time.deltaTime;
        if(timer >= deleteTime)
        {
            if (collidingWithPlayer == true)
            {
                spawnManager.GetComponent<WaveHandler>().changespeed(0.2f);
                spawnManager.GetComponent<WaveHandler>().WaveSpawnEnabled(true);
                spawnManager.GetComponent<Background_Tile_Spawner>().ChangeOceanScrollSpeed(0.5f);
            }
            spawnManager.GetComponent<Background_Tile_Spawner>().ChangeOceanScrollSpeed(0.5f);
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

    public void ChangeSpeed(float newSpeed)
    {
        movementspeed = newSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            collidingWithPlayer = true;
            spawnManager.GetComponent<WaveHandler>().changespeed(0);
            spawnManager.GetComponent<WaveHandler>().WaveSpawnEnabled(false);
            spawnManager.GetComponent<Background_Tile_Spawner>().ChangeOceanScrollSpeed(1f);
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            collidingWithPlayer = false;
            spawnManager.GetComponent<WaveHandler>().changespeed(0.2f);
            spawnManager.GetComponent<WaveHandler>().WaveSpawnEnabled(true);
            spawnManager.GetComponent<Background_Tile_Spawner>().ChangeOceanScrollSpeed(0.5f);
        }
    }
}
