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
    public Sprite wave1;
    public Sprite wave2;
    public float animationTimer;
    float animationCounter = 2;
    private PlayerMovement playerMovement;
    private bool collidingWithPlayer = false;

    // Use this for initialization
    void Start () {
        SetUp();


    }

    // Update is called once per frame
    void Update () {
        move();
        timer += Time.deltaTime;
        animationTimer += Time.deltaTime;
        if(timer >= deleteTime)
        {
            if (collidingWithPlayer == true)
            {
                spawnManager.GetComponent<WaveHandler>().ChangeSpeed(0.2f);
                spawnManager.GetComponent<WaveHandler>().WaveSpawnEnabled(true);
                spawnManager.GetComponent<Background_Tile_Spawner>().ChangeOceanScrollSpeed(0.5f);
            }
            spawnManager.GetComponent<Background_Tile_Spawner>().ChangeOceanScrollSpeed(0.5f);
            selfdestruct();
        }
        if(animationTimer > 0.5f)
        {
            animationTimer = 0;
            switchframe();
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
        deleteTime = Random.Range(7, 15);
        spawnManager = GameObject.FindGameObjectWithTag("GameController");
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }
    public void move()
    {
        transform.Translate(direction * movementspeed * Time.deltaTime);
    }
    public void selfdestruct()
    {
        playerMovement.StopSurfing();
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
            spawnManager.GetComponent<WaveHandler>().ChangeSpeed(0);
            spawnManager.GetComponent<WaveHandler>().WaveSpawnEnabled(false);
            spawnManager.GetComponent<Background_Tile_Spawner>().ChangeOceanScrollSpeed(1f);
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            collidingWithPlayer = false;
            spawnManager.GetComponent<WaveHandler>().ChangeSpeed(0.2f);
            spawnManager.GetComponent<WaveHandler>().WaveSpawnEnabled(true);
            spawnManager.GetComponent<Background_Tile_Spawner>().ChangeOceanScrollSpeed(0.5f);
        }
    }
    public void switchframe()
    {
        if (animationCounter == 1)
        {
 
            this.gameObject.GetComponent<SpriteRenderer>().sprite = wave2;
            animationCounter = 2;
        }
        else if (animationCounter == 2)
        {

            this.gameObject.GetComponent<SpriteRenderer>().sprite = wave1;
            animationCounter = 1;
        }
    }
}
