using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour {
    float deathTimer;
    float lifespan = 20;
    Vector2 direction;
    float speed = 0.1f;
	// Use this for initialization
	void Start () {
        setup();
	}
	
	// Update is called once per frame
	void Update () {
        move();
        deathTimer += Time.deltaTime;
        if (deathTimer >= lifespan)
        {
            selfDestruct();
        }
    }
    public void setup()
    {
        direction = Vector2.down + Vector2.left;
        direction.Normalize();
    }
    public void move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
    public void changeSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
    public void selfDestruct()
    {
        GameObject.Find("Spawner Manager").GetComponent<ObstacleHandler>().obsList.Remove(this.gameObject);
        Destroy(this);
    }

}
