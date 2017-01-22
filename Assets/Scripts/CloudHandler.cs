using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudHandler : MonoBehaviour {

    float timer;
    public float spawnRate = 2;
    public GameObject cloud;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {

            spawnCloud();
            timer = 0;
        }

    }
    public void spawnCloud()
    {
        float x = Random.Range(100, 300);
        x = x / 100;
        float y = (-1 * x) + 4;

        Vector2 spawnloc = new Vector2(x, y);
        GameObject.Instantiate(cloud, spawnloc, new Quaternion(0, 0, 0, 0));
    }
}
