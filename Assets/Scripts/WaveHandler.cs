using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveHandler : MonoBehaviour {
    Vector2 spawnloc;
    float currentSpeed;
    float x, y;
    float timer;
    public float spawntime = 1;
    public GameObject Wave;

    private bool spawnEnabled = true;
    public List<GameObject> wavesList = new List<GameObject>();
	// Use this for initialization
	void Start () {
        ChangeSpeed(0.2f);
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        if (timer >= spawntime && spawnEnabled == true)
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
        GameObject wave = Instantiate(Wave, spawnloc, new Quaternion(0, 0, 0, 0));
        wavesList.Add(wave);
        wave.GetComponent<WaveBehaviour>().movementspeed = currentSpeed;
    }
    public void ChangeSpeed(float speed)
    {
        currentSpeed = speed;
        foreach(GameObject wave in wavesList)
        {
            wave.gameObject.GetComponent<WaveBehaviour>().movementspeed = speed;
        }
    }

    public void WaveSpawnEnabled(bool enabled)
    {
        spawnEnabled = enabled;
    }
    
}
