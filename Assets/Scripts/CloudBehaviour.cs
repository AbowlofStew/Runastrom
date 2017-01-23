using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehaviour : MonoBehaviour {
    float deathTimer;
    float lifespan = 15;
    Vector2 direction;
    float speed = 0.3f;
    // Use this for initialization
    void Start () {
        direction = Vector2.down + Vector2.left;
        direction.Normalize();
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        move();
        deathTimer += Time.deltaTime;
        if (deathTimer >= lifespan)
        {
          selfDestruct();
        }
        
    }
    public void move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
    public void selfDestruct()
    {
        Destroy(this.gameObject);
    }
}

