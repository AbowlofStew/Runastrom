using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Tile_Spawner : MonoBehaviour {
    public GameObject Tile;
    private float xBounds;
    private float yBounds;
    private Vector3 screenUpperRight;
    public List<Background_Script> ocean;
    // Use this for initialization
    void Start () {

        xBounds = Tile.GetComponent<SpriteRenderer>().bounds.size.x;
        yBounds = Tile.GetComponent<SpriteRenderer>().bounds.size.y;

        screenUpperRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 1));
        Vector3 bottomRight = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 1));
        Vector3 screenSize = new Vector3(screenUpperRight.x - bottomRight.x + xBounds, screenUpperRight.y - bottomRight.y + yBounds, 0);
        Vector3 p = screenUpperRight;
        p.Set(p.x + xBounds, p.y + yBounds, p.z);

        for (int j = 0; j < 8; j++)
        {
            for (int i = 0; i < 16; i++)
            {
                Instantiate(Tile, p, Quaternion.identity);
                ocean.Add(Tile.GetComponent<Background_Script>());
                p.Set(p.x - screenSize.x / 14, p.y, p.z);
            }
            p.Set(screenUpperRight.x + xBounds, p.y - screenSize.y / 7, p.z);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeOceanScrollSpeed(float speed)
    {
        foreach(Background_Script b in ocean)
        {
            b.slowScrollSpeed = speed;
        }
    }
}
