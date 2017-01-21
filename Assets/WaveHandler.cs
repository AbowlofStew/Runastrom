using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveHandler : MonoBehaviour {
    Vector2 spawnloc;
    float x, y;
    float timer;
    public float spawntime = 1;
    public GameObject Wave;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= spawntime)
        {
            timer = 0;
            spawnWave();
        }
	}
    public void generateSpawnLoc()
    {
        x = Random.Range(0,-200);
        x = x / 100;
        y = (-1*x) - 2;
        spawnloc = new Vector2(x, y);
    }
    public void spawnWave()
    {
        generateSpawnLoc();
        Instantiate(Wave, spawnloc, new Quaternion(0,0,0,0));
    }
    
}
